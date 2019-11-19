using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace CrestronModule_EVENTSKED2_V12
{
    public class CrestronModuleClass_EVENTSKED2_V12 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput ENABLE;
        Crestron.Logos.SplusObjects.DigitalInput SAVE_EDIT_EVENT;
        Crestron.Logos.SplusObjects.DigitalInput REVERT_EDIT_EVENT;
        Crestron.Logos.SplusObjects.DigitalInput EDIT_FIRST_EVENT;
        Crestron.Logos.SplusObjects.DigitalInput EDIT_NEXT_EVENT;
        Crestron.Logos.SplusObjects.DigitalInput EDIT_PREV_EVENT;
        Crestron.Logos.SplusObjects.DigitalInput EDIT_LAST_EVENT;
        Crestron.Logos.SplusObjects.DigitalInput HOUR_UP;
        Crestron.Logos.SplusObjects.DigitalInput HOUR_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput MINUTE_UP;
        Crestron.Logos.SplusObjects.DigitalInput MINUTE_DOWN;
        Crestron.Logos.SplusObjects.DigitalInput AM;
        Crestron.Logos.SplusObjects.DigitalInput PM;
        Crestron.Logos.SplusObjects.DigitalInput SUNRISE;
        Crestron.Logos.SplusObjects.DigitalInput SUNSET;
        Crestron.Logos.SplusObjects.DigitalInput SUSPEND;
        Crestron.Logos.SplusObjects.DigitalInput RESUME;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> EDIT_EVENT_FLAGS;
        Crestron.Logos.SplusObjects.AnalogInput EDIT_EVENT;
        Crestron.Logos.SplusObjects.AnalogInput MORNING_HOUR;
        Crestron.Logos.SplusObjects.AnalogInput MORNING_MIN;
        Crestron.Logos.SplusObjects.AnalogInput NIGHT_HOUR;
        Crestron.Logos.SplusObjects.AnalogInput NIGHT_MIN;
        Crestron.Logos.SplusObjects.StringInput FILENAME__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput READ_ERROR;
        Crestron.Logos.SplusObjects.DigitalOutput WRITE_ERROR;
        Crestron.Logos.SplusObjects.DigitalOutput EDIT_EVENT_SUSPENDED;
        Crestron.Logos.SplusObjects.DigitalOutput EDIT_EVENT_READONLY;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> EVENT_DUE;
        Crestron.Logos.SplusObjects.AnalogOutput EDIT_EVENT_NUMBER;
        Crestron.Logos.SplusObjects.AnalogOutput EDIT_EVENT_TIMEBASE;
        Crestron.Logos.SplusObjects.AnalogOutput EDIT_EVENT_VALID_DAYS;
        Crestron.Logos.SplusObjects.AnalogOutput EDIT_EVENT_VALID_MONTHS;
        Crestron.Logos.SplusObjects.StringOutput EDIT_EVENT_NAME__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput EDIT_EVENT_TIME__DOLLAR__;
        Crestron.Logos.SplusObjects.StringOutput MESSAGE__DOLLAR__;
        EVENTINFO [] G_EVENTS;
        EVENTINFO G_EDITEVENT;
        ushort [] G_IMONTHMASK;
        ushort [] G_IDAYOFWEEKMASK;
        ushort G_IEDITEVENT = 0;
        ushort G_IMAXUSEDEVENT = 0;
        ushort G_BFILENAMEVALID = 0;
        ushort G_BWRITINGFILE = 0;
        FILE_INFO G_FIDATAFILE;
        private ushort GETBIT (  SplusExecutionContext __context__, ushort ISOURCE , ushort IBITNUM ) 
            { 
            
            __context__.SourceCodeLine = 167;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IBITNUM > 15 ))  ) ) 
                {
                __context__.SourceCodeLine = 168;
                return (ushort)( 0) ; 
                }
            
            __context__.SourceCodeLine = 170;
            return (ushort)( ((ISOURCE & (1 << IBITNUM)) >> IBITNUM)) ; 
            
            }
            
        private ushort SETBIT (  SplusExecutionContext __context__, ushort ISOURCE , ushort IBITNUM , ushort IVALUE ) 
            { 
            
            __context__.SourceCodeLine = 175;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IBITNUM > 15 ))  ) ) 
                {
                __context__.SourceCodeLine = 176;
                return (ushort)( ISOURCE) ; 
                }
            
            __context__.SourceCodeLine = 178;
            if ( Functions.TestForTrue  ( ( IVALUE)  ) ) 
                {
                __context__.SourceCodeLine = 179;
                return (ushort)( (ISOURCE | (1 << IBITNUM))) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 181;
                return (ushort)( (ISOURCE & Functions.OnesComplement( (1 << IBITNUM) ))) ; 
                }
            
            
            return 0; // default return value (none specified in module)
            }
            
        private ushort TOGGLEBIT (  SplusExecutionContext __context__, ushort ISOURCE , ushort IBITNUM ) 
            { 
            ushort IBITVALUE = 0;
            
            
            __context__.SourceCodeLine = 188;
            IBITVALUE = (ushort) ( GETBIT( __context__ , (ushort)( ISOURCE ) , (ushort)( IBITNUM ) ) ) ; 
            __context__.SourceCodeLine = 190;
            if ( Functions.TestForTrue  ( ( IBITVALUE)  ) ) 
                {
                __context__.SourceCodeLine = 191;
                return (ushort)( SETBIT( __context__ , (ushort)( ISOURCE ) , (ushort)( IBITNUM ) , (ushort)( 0 ) )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 193;
                return (ushort)( SETBIT( __context__ , (ushort)( ISOURCE ) , (ushort)( IBITNUM ) , (ushort)( 1 ) )) ; 
                }
            
            
            return 0; // default return value (none specified in module)
            }
            
        private void DUMP (  SplusExecutionContext __context__ ) 
            { 
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 200;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)G_IMAXUSEDEVENT; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 202;
                Print( "===========================================\r\n") ; 
                __context__.SourceCodeLine = 203;
                Print( "EVENT #{0:d}\r\n", (ushort)I) ; 
                __context__.SourceCodeLine = 204;
                Print( "===========================================\r\n") ; 
                __context__.SourceCodeLine = 205;
                Print( "      NAME: {0}\r\n", G_EVENTS [ I] . NAME ) ; 
                __context__.SourceCodeLine = 206;
                Print( "  TIMEBASE: {0:d}\r\n", (ushort)G_EVENTS[ I ].TIMEBASE) ; 
                __context__.SourceCodeLine = 207;
                Print( "      TIME: {0:d}\r\n", (short)G_EVENTS[ I ]._TIME) ; 
                __context__.SourceCodeLine = 208;
                Print( "      DAYS: {0:X}\r\n", G_EVENTS[ I ].VALIDDAYS) ; 
                __context__.SourceCodeLine = 209;
                Print( "    MONTHS: {0:X}\r\n", G_EVENTS[ I ].VALIDMONTHS) ; 
                __context__.SourceCodeLine = 210;
                Print( "   SUSPEND: {0:x}\r\n", G_EVENTS[ I ].SUSPENDED) ; 
                __context__.SourceCodeLine = 200;
                } 
            
            
            }
            
        private ushort EVENTISVALIDTODAY (  SplusExecutionContext __context__, ushort IEVENTNUM , ushort IDAYOFWEEK , ushort IMONTH ) 
            { 
            
            __context__.SourceCodeLine = 234;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((G_EVENTS[ IEVENTNUM ].VALIDMONTHS & G_IMONTHMASK[ IMONTH ]) == 0))  ) ) 
                {
                __context__.SourceCodeLine = 235;
                return (ushort)( 0) ; 
                }
            
            __context__.SourceCodeLine = 238;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ((G_EVENTS[ IEVENTNUM ].VALIDDAYS & G_IDAYOFWEEKMASK[ IDAYOFWEEK ]) == 0))  ) ) 
                {
                __context__.SourceCodeLine = 239;
                return (ushort)( 0) ; 
                }
            
            __context__.SourceCodeLine = 242;
            return (ushort)( 1) ; 
            
            }
            
        private ushort GETINTEGERFROMBITFIELDSTRING (  SplusExecutionContext __context__, CrestronString SBITFIELD ) 
            { 
            ushort ILEN = 0;
            
            ushort IBYTE = 0;
            
            ushort ITEMP = 0;
            
            
            __context__.SourceCodeLine = 270;
            ITEMP = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 272;
            ILEN = (ushort) ( Functions.Length( SBITFIELD ) ) ; 
            __context__.SourceCodeLine = 274;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ILEN > 16 ))  ) ) 
                {
                __context__.SourceCodeLine = 275;
                return (ushort)( Functions.ToInteger( -( 1 ) )) ; 
                }
            
            __context__.SourceCodeLine = 277;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)ILEN; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( IBYTE  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IBYTE  >= __FN_FORSTART_VAL__1) && (IBYTE  <= __FN_FOREND_VAL__1) ) : ( (IBYTE  <= __FN_FORSTART_VAL__1) && (IBYTE  >= __FN_FOREND_VAL__1) ) ; IBYTE  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 279;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( SBITFIELD , (int)( IBYTE ) ) == 88))  ) ) 
                    { 
                    __context__.SourceCodeLine = 281;
                    ITEMP = (ushort) ( (ITEMP + (1 << (IBYTE - 1))) ) ; 
                    } 
                
                __context__.SourceCodeLine = 277;
                } 
            
            __context__.SourceCodeLine = 285;
            return (ushort)( ITEMP) ; 
            
            }
            
        private CrestronString GETBITFIELDSTRINGFROMINTEGER (  SplusExecutionContext __context__, ushort IBITFIELD , ushort INUMBITS ) 
            { 
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, this );
            
            ushort IBIT = 0;
            
            
            __context__.SourceCodeLine = 308;
            STEMP  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 310;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 0 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)(INUMBITS - 1); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( IBIT  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (IBIT  >= __FN_FORSTART_VAL__1) && (IBIT  <= __FN_FOREND_VAL__1) ) : ( (IBIT  <= __FN_FORSTART_VAL__1) && (IBIT  >= __FN_FOREND_VAL__1) ) ; IBIT  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 312;
                if ( Functions.TestForTrue  ( ( (IBITFIELD & (1 << IBIT)))  ) ) 
                    {
                    __context__.SourceCodeLine = 313;
                    STEMP  .UpdateValue ( STEMP + Functions.Chr (  (int) ( 88 ) )  ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 315;
                    STEMP  .UpdateValue ( STEMP + Functions.Chr (  (int) ( 45 ) )  ) ; 
                    }
                
                __context__.SourceCodeLine = 310;
                } 
            
            __context__.SourceCodeLine = 318;
            return ( STEMP ) ; 
            
            }
            
        private void COPYEVENT (  SplusExecutionContext __context__, EVENTINFO SRC , ref EVENTINFO DEST ) 
            { 
            
            __context__.SourceCodeLine = 337;
            DEST . NAME  .UpdateValue ( SRC . NAME  ) ; 
            __context__.SourceCodeLine = 338;
            DEST . TIMEBASE = (ushort) ( SRC.TIMEBASE ) ; 
            __context__.SourceCodeLine = 339;
            DEST . _TIME = (short) ( SRC._TIME ) ; 
            __context__.SourceCodeLine = 340;
            DEST . VALIDDAYS = (ushort) ( SRC.VALIDDAYS ) ; 
            __context__.SourceCodeLine = 341;
            DEST . VALIDMONTHS = (ushort) ( SRC.VALIDMONTHS ) ; 
            __context__.SourceCodeLine = 342;
            DEST . FREE = (ushort) ( SRC.FREE ) ; 
            __context__.SourceCodeLine = 343;
            DEST . SUSPENDED = (ushort) ( SRC.SUSPENDED ) ; 
            __context__.SourceCodeLine = 344;
            DEST . HIDDENSTATE = (ushort) ( SRC.HIDDENSTATE ) ; 
            __context__.SourceCodeLine = 345;
            DEST . READONLY = (ushort) ( SRC.READONLY ) ; 
            __context__.SourceCodeLine = 346;
            DEST . LASTMODIFIED  .UpdateValue ( SRC . LASTMODIFIED  ) ; 
            __context__.SourceCodeLine = 347;
            DEST . USERDATA  .UpdateValue ( SRC . USERDATA  ) ; 
            
            }
            
        private CrestronString GETTIMESTRING (  SplusExecutionContext __context__, short ITIME , ushort ITIMEBASE ) 
            { 
            short IHOUR = 0;
            
            ushort IMIN = 0;
            
            CrestronString STIME;
            STIME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            
            __context__.SourceCodeLine = 373;
            IHOUR = (short) ( (Functions.Abs( ITIME ) / 60) ) ; 
            __context__.SourceCodeLine = 374;
            IMIN = (ushort) ( Mod( Functions.Abs( ITIME ) , 60 ) ) ; 
            __context__.SourceCodeLine = 376;
            
                {
                int __SPLS_TMPVAR__SWTCH_1__ = ((int)ITIMEBASE);
                
                    { 
                    if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 0) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 380;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IHOUR == 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 381;
                            IHOUR = (short) ( 12 ) ; 
                            }
                        
                        __context__.SourceCodeLine = 382;
                        MakeString ( STIME , "{0:d}:{1:d2} AM", (ushort)IHOUR, (ushort)IMIN) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 387;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IHOUR == 0))  ) ) 
                            {
                            __context__.SourceCodeLine = 388;
                            IHOUR = (short) ( 12 ) ; 
                            }
                        
                        __context__.SourceCodeLine = 389;
                        MakeString ( STIME , "{0:d}:{1:d2} PM", (ushort)IHOUR, (ushort)IMIN) ; 
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 394;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITIME >= 0 ))  ) ) 
                            {
                            __context__.SourceCodeLine = 395;
                            MakeString ( STIME , "Sunrise + {0:d}:{1:d2}", (ushort)IHOUR, (ushort)IMIN) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 397;
                            MakeString ( STIME , "Sunrise - {0:d}:{1:d2}", (ushort)IHOUR, (ushort)IMIN) ; 
                            }
                        
                        } 
                    
                    else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                        { 
                        __context__.SourceCodeLine = 402;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( ITIME >= 0 ))  ) ) 
                            {
                            __context__.SourceCodeLine = 403;
                            MakeString ( STIME , "Sunset + {0:d}:{1:d2}", (ushort)IHOUR, (ushort)IMIN) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 405;
                            MakeString ( STIME , "Sunset - {0:d}:{1:d2}", (ushort)IHOUR, (ushort)IMIN) ; 
                            }
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 409;
                        STIME  .UpdateValue ( "ERROR: Invalid time"  ) ; 
                        }
                    
                    } 
                    
                }
                
            
            __context__.SourceCodeLine = 413;
            return ( STIME ) ; 
            
            }
            
        private void UPDATEEDITEVENTTIME (  SplusExecutionContext __context__ ) 
            { 
            short ITIME = 0;
            
            ushort ITIMEBASE = 0;
            
            
            __context__.SourceCodeLine = 422;
            EDIT_EVENT_TIMEBASE  .Value = (ushort) ( G_EDITEVENT.TIMEBASE ) ; 
            __context__.SourceCodeLine = 424;
            ITIME = (short) ( G_EDITEVENT._TIME ) ; 
            __context__.SourceCodeLine = 425;
            ITIMEBASE = (ushort) ( G_EDITEVENT.TIMEBASE ) ; 
            __context__.SourceCodeLine = 426;
            EDIT_EVENT_TIME__DOLLAR__  .UpdateValue ( GETTIMESTRING (  __context__ , (short)( ITIME ), (ushort)( ITIMEBASE ))  ) ; 
            
            }
            
        private void UPDATEEDITEVENTFLAGS (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 432;
            EDIT_EVENT_VALID_DAYS  .Value = (ushort) ( G_EDITEVENT.VALIDDAYS ) ; 
            __context__.SourceCodeLine = 433;
            EDIT_EVENT_VALID_MONTHS  .Value = (ushort) ( G_EDITEVENT.VALIDMONTHS ) ; 
            
            }
            
        private void UPDATEEDITEVENTSUSPENDED (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 438;
            EDIT_EVENT_SUSPENDED  .Value = (ushort) ( G_EVENTS[ G_IEDITEVENT ].SUSPENDED ) ; 
            __context__.SourceCodeLine = 439;
            
            
            }
            
        private void UPDATEEDITEVENTREADONLY (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 446;
            EDIT_EVENT_READONLY  .Value = (ushort) ( G_EDITEVENT.READONLY ) ; 
            
            }
            
        private void SETEDITEVENT (  SplusExecutionContext __context__, ushort IEVENTNUM ) 
            { 
            
            __context__.SourceCodeLine = 466;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IEVENTNUM < 1 ))  ) ) 
                {
                __context__.SourceCodeLine = 467;
                G_IEDITEVENT = (ushort) ( 1 ) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 468;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IEVENTNUM > G_IMAXUSEDEVENT ))  ) ) 
                    {
                    __context__.SourceCodeLine = 469;
                    G_IEDITEVENT = (ushort) ( G_IMAXUSEDEVENT ) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 471;
                    G_IEDITEVENT = (ushort) ( IEVENTNUM ) ; 
                    }
                
                }
            
            __context__.SourceCodeLine = 473;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EVENTS[ G_IEDITEVENT ].FREE == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 475;
                COPYEVENT (  __context__ , G_EVENTS[ G_IEDITEVENT ],   ref  G_EDITEVENT ) ; 
                __context__.SourceCodeLine = 477;
                UPDATEEDITEVENTFLAGS (  __context__  ) ; 
                __context__.SourceCodeLine = 478;
                UPDATEEDITEVENTTIME (  __context__  ) ; 
                __context__.SourceCodeLine = 479;
                UPDATEEDITEVENTSUSPENDED (  __context__  ) ; 
                __context__.SourceCodeLine = 480;
                UPDATEEDITEVENTREADONLY (  __context__  ) ; 
                __context__.SourceCodeLine = 481;
                EDIT_EVENT_NUMBER  .Value = (ushort) ( G_IEDITEVENT ) ; 
                __context__.SourceCodeLine = 482;
                EDIT_EVENT_NAME__DOLLAR__  .UpdateValue ( G_EDITEVENT . NAME  ) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 486;
                Print( "ERROR: Event {0:d} is not in use.\r\n", (short)G_IEDITEVENT) ; 
                __context__.SourceCodeLine = 487;
                EDIT_EVENT_VALID_DAYS  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 488;
                EDIT_EVENT_VALID_MONTHS  .Value = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 489;
                EDIT_EVENT_NAME__DOLLAR__  .UpdateValue ( "ERROR"  ) ; 
                __context__.SourceCodeLine = 490;
                EDIT_EVENT_TIME__DOLLAR__  .UpdateValue ( "ERROR"  ) ; 
                } 
            
            
            }
            
        private short LOADEVENTS (  SplusExecutionContext __context__ ) 
            { 
            short IFILEHANDLE = 0;
            
            short IERRCODE = 0;
            
            CrestronString SREADBUF;
            SREADBUF  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 612, this );
            
            CrestronString SLINE;
            SLINE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
            
            CrestronString STEMP;
            STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
            
            ushort IEVENTNUM = 0;
            ushort ICHUNKCOUNT = 0;
            
            ushort I = 0;
            ushort BBUFFERDONE = 0;
            ushort SEARCH_TEMP = 0;
            
            
            __context__.SourceCodeLine = 522;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( StartFileOperations() < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 524;
                Print( "ERROR: Cannot start file ops\r\n") ; 
                __context__.SourceCodeLine = 525;
                Functions.Pulse ( 50, READ_ERROR ) ; 
                __context__.SourceCodeLine = 526;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 527;
                return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                } 
            
            __context__.SourceCodeLine = 540;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FindFirst( FILENAME__DOLLAR__ , ref G_FIDATAFILE ) != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 542;
                Print( "ERROR: Could not find file {0}\r\n", FILENAME__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 543;
                Functions.Pulse ( 50, READ_ERROR ) ; 
                __context__.SourceCodeLine = 544;
                FindClose ( ) ; 
                __context__.SourceCodeLine = 545;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 546;
                return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                } 
            
            __context__.SourceCodeLine = 548;
            FindClose ( ) ; 
            __context__.SourceCodeLine = 550;
            IFILEHANDLE = (short) ( FileOpen( FILENAME__DOLLAR__ ,(ushort) (0 | 16384) ) ) ; 
            __context__.SourceCodeLine = 551;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLE < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 553;
                Print( "ERROR: Cannot open file '{0}' for read.\r\n Error Code={1:d}\r\n", FILENAME__DOLLAR__ , (short)IFILEHANDLE) ; 
                __context__.SourceCodeLine = 554;
                Functions.Pulse ( 50, READ_ERROR ) ; 
                __context__.SourceCodeLine = 555;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 556;
                return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                } 
            
            __context__.SourceCodeLine = 560;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)250; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 562;
                G_EVENTS [ I] . FREE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 560;
                } 
            
            __context__.SourceCodeLine = 565;
            SLINE  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 566;
            ICHUNKCOUNT = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 567;
            while ( Functions.TestForTrue  ( ( FileRead( (short)( IFILEHANDLE ) , SREADBUF , (ushort)( 512 ) ))  ) ) 
                { 
                __context__.SourceCodeLine = 572;
                SREADBUF  .UpdateValue ( SLINE + SREADBUF  ) ; 
                __context__.SourceCodeLine = 573;
                BBUFFERDONE = (ushort) ( 0 ) ; 
                __context__.SourceCodeLine = 575;
                ICHUNKCOUNT = (ushort) ( (ICHUNKCOUNT + 1) ) ; 
                __context__.SourceCodeLine = 577;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ICHUNKCOUNT == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 579;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Left( SREADBUF , (int)( 1 ) ) == "#"))  ) ) 
                        { 
                        __context__.SourceCodeLine = 581;
                        SLINE  .UpdateValue ( Functions.Remove ( "\u000D\u000A" , SREADBUF )  ) ; 
                        __context__.SourceCodeLine = 583;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Atoi( SLINE ) > 2 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 585;
                            Print( "ERROR: Schedule version is later than {0:d}\r\n", (ushort)2) ; 
                            __context__.SourceCodeLine = 586;
                            FileClose (  (short) ( IFILEHANDLE ) ) ; 
                            __context__.SourceCodeLine = 587;
                            EndFileOperations ( ) ; 
                            __context__.SourceCodeLine = 589;
                            return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                            } 
                        
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 594;
                do 
                    { 
                    __context__.SourceCodeLine = 596;
                    SLINE  .UpdateValue ( Functions.Remove ( "\u000D\u000A" , SREADBUF )  ) ; 
                    __context__.SourceCodeLine = 598;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SLINE ) == 0))  ) ) 
                        {
                        __context__.SourceCodeLine = 600;
                        BBUFFERDONE = (ushort) ( 1 ) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 602;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( SLINE , (int)( 1 ) ) != 59))  ) ) 
                            { 
                            __context__.SourceCodeLine = 604;
                            IEVENTNUM = (ushort) ( Functions.Atoi( Functions.Remove( "," , SLINE ) ) ) ; 
                            __context__.SourceCodeLine = 606;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( IEVENTNUM < 0 ) ) || Functions.TestForTrue ( Functions.BoolToInt ( IEVENTNUM > 250 ) )) ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 608;
                                Print( "ERROR: Invalid event number. ({0:d})\r\n", (short)IEVENTNUM) ; 
                                __context__.SourceCodeLine = 609;
                                break ; 
                                } 
                            
                            __context__.SourceCodeLine = 613;
                            STEMP  .UpdateValue ( Functions.Remove ( "," , SLINE )  ) ; 
                            __context__.SourceCodeLine = 614;
                            G_EVENTS [ IEVENTNUM] . NAME  .UpdateValue ( Functions.Left ( STEMP ,  (int) ( (Functions.Length( STEMP ) - 1) ) )  ) ; 
                            __context__.SourceCodeLine = 617;
                            G_EVENTS [ IEVENTNUM] . TIMEBASE = (ushort) ( Functions.Atoi( Functions.Remove( "," , SLINE ) ) ) ; 
                            __context__.SourceCodeLine = 620;
                            STEMP  .UpdateValue ( Functions.Remove ( "," , SLINE )  ) ; 
                            __context__.SourceCodeLine = 622;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( STEMP ) == 0))  ) ) 
                                {
                                __context__.SourceCodeLine = 623;
                                G_EVENTS [ IEVENTNUM] . _TIME = (short) ( 0 ) ; 
                                }
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 626;
                                G_EVENTS [ IEVENTNUM] . _TIME = (short) ( Functions.Atoi( STEMP ) ) ; 
                                __context__.SourceCodeLine = 629;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Byte( STEMP , (int)( 1 ) ) == 45))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 630;
                                    G_EVENTS [ IEVENTNUM] . _TIME = (short) ( Functions.ToInteger( -( G_EVENTS[ IEVENTNUM ]._TIME ) ) ) ; 
                                    }
                                
                                } 
                            
                            __context__.SourceCodeLine = 634;
                            STEMP  .UpdateValue ( Functions.Remove ( "," , SLINE )  ) ; 
                            __context__.SourceCodeLine = 635;
                            G_EVENTS [ IEVENTNUM] . VALIDDAYS = (ushort) ( GETINTEGERFROMBITFIELDSTRING( __context__ , STEMP ) ) ; 
                            __context__.SourceCodeLine = 639;
                            SEARCH_TEMP = (ushort) ( Functions.Find( "," , SLINE ) ) ; 
                            __context__.SourceCodeLine = 642;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SEARCH_TEMP == 0))  ) ) 
                                { 
                                __context__.SourceCodeLine = 644;
                                STEMP  .UpdateValue ( Functions.Remove ( "\u000D\u000A" , SLINE )  ) ; 
                                __context__.SourceCodeLine = 645;
                                G_EVENTS [ IEVENTNUM] . VALIDMONTHS = (ushort) ( GETINTEGERFROMBITFIELDSTRING( __context__ , STEMP ) ) ; 
                                __context__.SourceCodeLine = 646;
                                G_EVENTS [ IEVENTNUM] . SUSPENDED = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 647;
                                G_EVENTS [ IEVENTNUM] . HIDDENSTATE = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 648;
                                G_EVENTS [ IEVENTNUM] . READONLY = (ushort) ( 0 ) ; 
                                __context__.SourceCodeLine = 649;
                                G_EVENTS [ IEVENTNUM] . LASTMODIFIED  .UpdateValue ( ""  ) ; 
                                __context__.SourceCodeLine = 650;
                                G_EVENTS [ IEVENTNUM] . USERDATA  .UpdateValue ( ""  ) ; 
                                } 
                            
                            else 
                                { 
                                __context__.SourceCodeLine = 656;
                                STEMP  .UpdateValue ( Functions.Remove ( "," , SLINE )  ) ; 
                                __context__.SourceCodeLine = 657;
                                G_EVENTS [ IEVENTNUM] . VALIDMONTHS = (ushort) ( GETINTEGERFROMBITFIELDSTRING( __context__ , STEMP ) ) ; 
                                __context__.SourceCodeLine = 659;
                                SEARCH_TEMP = (ushort) ( Functions.Find( "," , SLINE ) ) ; 
                                __context__.SourceCodeLine = 662;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SEARCH_TEMP == 0))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 664;
                                    STEMP  .UpdateValue ( Functions.Remove ( "\u000D\u000A" , SLINE )  ) ; 
                                    __context__.SourceCodeLine = 665;
                                    G_EVENTS [ IEVENTNUM] . SUSPENDED = (ushort) ( Functions.Atoi( STEMP ) ) ; 
                                    __context__.SourceCodeLine = 666;
                                    G_EVENTS [ IEVENTNUM] . HIDDENSTATE = (ushort) ( 0 ) ; 
                                    __context__.SourceCodeLine = 667;
                                    G_EVENTS [ IEVENTNUM] . READONLY = (ushort) ( 0 ) ; 
                                    __context__.SourceCodeLine = 668;
                                    G_EVENTS [ IEVENTNUM] . LASTMODIFIED  .UpdateValue ( ""  ) ; 
                                    __context__.SourceCodeLine = 669;
                                    G_EVENTS [ IEVENTNUM] . USERDATA  .UpdateValue ( ""  ) ; 
                                    } 
                                
                                else 
                                    { 
                                    __context__.SourceCodeLine = 675;
                                    STEMP  .UpdateValue ( Functions.Remove ( "," , SLINE )  ) ; 
                                    __context__.SourceCodeLine = 676;
                                    G_EVENTS [ IEVENTNUM] . SUSPENDED = (ushort) ( Functions.Atoi( STEMP ) ) ; 
                                    __context__.SourceCodeLine = 678;
                                    SEARCH_TEMP = (ushort) ( Functions.Find( "," , SLINE ) ) ; 
                                    __context__.SourceCodeLine = 681;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SEARCH_TEMP == 0))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 683;
                                        STEMP  .UpdateValue ( Functions.Remove ( "\u000D\u000A" , SLINE )  ) ; 
                                        __context__.SourceCodeLine = 686;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "H" , STEMP ) == 0))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 687;
                                            G_EVENTS [ IEVENTNUM] . HIDDENSTATE = (ushort) ( 0 ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 690;
                                            G_EVENTS [ IEVENTNUM] . HIDDENSTATE = (ushort) ( 1 ) ; 
                                            }
                                        
                                        __context__.SourceCodeLine = 693;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "R" , STEMP ) == 0))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 694;
                                            G_EVENTS [ IEVENTNUM] . READONLY = (ushort) ( 0 ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 697;
                                            G_EVENTS [ IEVENTNUM] . READONLY = (ushort) ( 1 ) ; 
                                            }
                                        
                                        __context__.SourceCodeLine = 699;
                                        G_EVENTS [ IEVENTNUM] . LASTMODIFIED  .UpdateValue ( ""  ) ; 
                                        __context__.SourceCodeLine = 700;
                                        G_EVENTS [ IEVENTNUM] . USERDATA  .UpdateValue ( ""  ) ; 
                                        } 
                                    
                                    else 
                                        { 
                                        __context__.SourceCodeLine = 706;
                                        STEMP  .UpdateValue ( Functions.Remove ( "," , SLINE )  ) ; 
                                        __context__.SourceCodeLine = 709;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "H" , STEMP ) == 0))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 710;
                                            G_EVENTS [ IEVENTNUM] . HIDDENSTATE = (ushort) ( 0 ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 713;
                                            G_EVENTS [ IEVENTNUM] . HIDDENSTATE = (ushort) ( 1 ) ; 
                                            }
                                        
                                        __context__.SourceCodeLine = 716;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "R" , STEMP ) == 0))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 717;
                                            G_EVENTS [ IEVENTNUM] . READONLY = (ushort) ( 0 ) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 720;
                                            G_EVENTS [ IEVENTNUM] . READONLY = (ushort) ( 1 ) ; 
                                            }
                                        
                                        __context__.SourceCodeLine = 722;
                                        SEARCH_TEMP = (ushort) ( Functions.Find( "," , SLINE ) ) ; 
                                        __context__.SourceCodeLine = 725;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (SEARCH_TEMP == 0))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 727;
                                            STEMP  .UpdateValue ( Functions.Remove ( "\u000D\u000A" , SLINE )  ) ; 
                                            __context__.SourceCodeLine = 728;
                                            G_EVENTS [ IEVENTNUM] . LASTMODIFIED  .UpdateValue ( Functions.Left ( STEMP ,  (int) ( (Functions.Length( STEMP ) - 2) ) )  ) ; 
                                            __context__.SourceCodeLine = 729;
                                            G_EVENTS [ IEVENTNUM] . USERDATA  .UpdateValue ( ""  ) ; 
                                            } 
                                        
                                        else 
                                            { 
                                            __context__.SourceCodeLine = 734;
                                            STEMP  .UpdateValue ( Functions.Remove ( "," , SLINE )  ) ; 
                                            __context__.SourceCodeLine = 735;
                                            G_EVENTS [ IEVENTNUM] . LASTMODIFIED  .UpdateValue ( Functions.Left ( STEMP ,  (int) ( (Functions.Length( STEMP ) - 1) ) )  ) ; 
                                            __context__.SourceCodeLine = 737;
                                            STEMP  .UpdateValue ( Functions.Remove ( "\u000D\u000A" , SLINE )  ) ; 
                                            __context__.SourceCodeLine = 738;
                                            G_EVENTS [ IEVENTNUM] . USERDATA  .UpdateValue ( Functions.Left ( STEMP ,  (int) ( (Functions.Length( STEMP ) - 2) ) )  ) ; 
                                            } 
                                        
                                        } 
                                    
                                    } 
                                
                                } 
                            
                            __context__.SourceCodeLine = 747;
                            G_EVENTS [ IEVENTNUM] . FREE = (ushort) ( 0 ) ; 
                            } 
                        
                        }
                    
                    } 
                while (false == ( Functions.TestForTrue  ( BBUFFERDONE) )); 
                __context__.SourceCodeLine = 754;
                if ( Functions.TestForTrue  ( ( Functions.Length( SREADBUF ))  ) ) 
                    {
                    __context__.SourceCodeLine = 755;
                    SLINE  .UpdateValue ( SREADBUF  ) ; 
                    }
                
                __context__.SourceCodeLine = 567;
                } 
            
            __context__.SourceCodeLine = 759;
            IERRCODE = (short) ( FileClose( (short)( IFILEHANDLE ) ) ) ; 
            __context__.SourceCodeLine = 760;
            
            __context__.SourceCodeLine = 764;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IERRCODE < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 766;
                Print( "ERROR: Closing file after read. Error code = {0:d}\r\n", (short)IERRCODE) ; 
                } 
            
            __context__.SourceCodeLine = 769;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( EndFileOperations() < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 771;
                Print( "ERROR: Ending file ops.\r\n") ; 
                } 
            
            __context__.SourceCodeLine = 775;
            ushort __FN_FORSTART_VAL__2 = (ushort) ( 250 ) ;
            ushort __FN_FOREND_VAL__2 = (ushort)0; 
            int __FN_FORSTEP_VAL__2 = (int)Functions.ToLongInteger( -( 1 ) ); 
            for ( I  = __FN_FORSTART_VAL__2; (__FN_FORSTEP_VAL__2 > 0)  ? ( (I  >= __FN_FORSTART_VAL__2) && (I  <= __FN_FOREND_VAL__2) ) : ( (I  <= __FN_FORSTART_VAL__2) && (I  >= __FN_FOREND_VAL__2) ) ; I  += (ushort)__FN_FORSTEP_VAL__2) 
                { 
                __context__.SourceCodeLine = 777;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EVENTS[ I ].FREE == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 779;
                    G_IMAXUSEDEVENT = (ushort) ( I ) ; 
                    __context__.SourceCodeLine = 780;
                    break ; 
                    } 
                
                __context__.SourceCodeLine = 775;
                } 
            
            __context__.SourceCodeLine = 784;
            ushort __FN_FORSTART_VAL__3 = (ushort) ( G_IEDITEVENT ) ;
            ushort __FN_FOREND_VAL__3 = (ushort)G_IMAXUSEDEVENT; 
            int __FN_FORSTEP_VAL__3 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__3; (__FN_FORSTEP_VAL__3 > 0)  ? ( (I  >= __FN_FORSTART_VAL__3) && (I  <= __FN_FOREND_VAL__3) ) : ( (I  <= __FN_FORSTART_VAL__3) && (I  >= __FN_FOREND_VAL__3) ) ; I  += (ushort)__FN_FORSTEP_VAL__3) 
                { 
                __context__.SourceCodeLine = 786;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].FREE == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].HIDDENSTATE == 0) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 788;
                    SETEDITEVENT (  __context__ , (ushort)( I )) ; 
                    __context__.SourceCodeLine = 789;
                    break ; 
                    } 
                
                __context__.SourceCodeLine = 784;
                } 
            
            __context__.SourceCodeLine = 793;
            
            
            return 0; // default return value (none specified in module)
            }
            
        private short WRITEEVENTFILE (  SplusExecutionContext __context__ ) 
            { 
            short IFILEHANDLE = 0;
            
            short IERRCODE = 0;
            
            CrestronString HIDDEN;
            HIDDEN  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
            
            CrestronString READONLY;
            READONLY  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
            
            CrestronString SWRITEBUF;
            SWRITEBUF  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
            
            CrestronString STIME;
            STIME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
            
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 822;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( StartFileOperations() < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 824;
                Print( "ERROR: Cannot start file ops\r\n") ; 
                __context__.SourceCodeLine = 825;
                Functions.Pulse ( 50, WRITE_ERROR ) ; 
                __context__.SourceCodeLine = 826;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 827;
                return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                } 
            
            __context__.SourceCodeLine = 830;
            G_BWRITINGFILE = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 842;
            IFILEHANDLE = (short) ( FileOpen( FILENAME__DOLLAR__ ,(ushort) (((256 | 1) | 512) | 16384) ) ) ; 
            __context__.SourceCodeLine = 843;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFILEHANDLE < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 845;
                Print( "ERROR: Cannot open/create file '{0}' for write.\r\nError Code={1:d}\r\n", FILENAME__DOLLAR__ , (short)IFILEHANDLE) ; 
                __context__.SourceCodeLine = 846;
                Functions.Pulse ( 50, WRITE_ERROR ) ; 
                __context__.SourceCodeLine = 847;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 848;
                return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                } 
            
            __context__.SourceCodeLine = 851;
            SWRITEBUF  .UpdateValue ( "#" + Functions.ItoA (  (int) ( 2 ) ) + "\u000D\u000A"  ) ; 
            __context__.SourceCodeLine = 853;
            FileWrite (  (short) ( IFILEHANDLE ) , SWRITEBUF ,  (ushort) ( Functions.Length( SWRITEBUF ) ) ) ; 
            __context__.SourceCodeLine = 855;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)G_IMAXUSEDEVENT; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 858;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EVENTS[ I ].FREE == 0))  ) ) 
                    { 
                    __context__.SourceCodeLine = 862;
                    MakeString ( STIME , "{0:d}", (short)G_EVENTS[ I ]._TIME) ; 
                    __context__.SourceCodeLine = 864;
                    HIDDEN  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 865;
                    READONLY  .UpdateValue ( ""  ) ; 
                    __context__.SourceCodeLine = 867;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EVENTS[ I ].HIDDENSTATE == 1))  ) ) 
                        {
                        __context__.SourceCodeLine = 868;
                        HIDDEN  .UpdateValue ( "H"  ) ; 
                        }
                    
                    __context__.SourceCodeLine = 870;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EVENTS[ I ].READONLY == 1))  ) ) 
                        {
                        __context__.SourceCodeLine = 871;
                        READONLY  .UpdateValue ( "R"  ) ; 
                        }
                    
                    __context__.SourceCodeLine = 873;
                    SWRITEBUF  .UpdateValue ( Functions.ItoA (  (int) ( I ) ) + "," + G_EVENTS [ I] . NAME + "," + Functions.ItoA (  (int) ( G_EVENTS[ I ].TIMEBASE ) ) + "," + STIME + "," + GETBITFIELDSTRINGFROMINTEGER (  __context__ , (ushort)( G_EVENTS[ I ].VALIDDAYS ), (ushort)( 7 )) + "," + GETBITFIELDSTRINGFROMINTEGER (  __context__ , (ushort)( G_EVENTS[ I ].VALIDMONTHS ), (ushort)( 12 )) + "," + Functions.ItoA (  (int) ( G_EVENTS[ I ].SUSPENDED ) ) + "," + HIDDEN + READONLY + "," + G_EVENTS [ I] . LASTMODIFIED + "," + G_EVENTS [ I] . USERDATA + "\u000D\u000A"  ) ; 
                    __context__.SourceCodeLine = 885;
                    FileWrite (  (short) ( IFILEHANDLE ) , SWRITEBUF ,  (ushort) ( Functions.Length( SWRITEBUF ) ) ) ; 
                    } 
                
                __context__.SourceCodeLine = 855;
                } 
            
            __context__.SourceCodeLine = 891;
            IERRCODE = (short) ( FileClose( (short)( IFILEHANDLE ) ) ) ; 
            __context__.SourceCodeLine = 892;
            
            __context__.SourceCodeLine = 896;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IERRCODE < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 898;
                Print( "ERROR: Closing file after write. Error code = ({0:d})\r\n", (short)IERRCODE) ; 
                } 
            
            __context__.SourceCodeLine = 903;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (FindFirst( FILENAME__DOLLAR__ , ref G_FIDATAFILE ) != 0))  ) ) 
                { 
                __context__.SourceCodeLine = 905;
                Print( "ERROR: Could not find file {0}\r\n", FILENAME__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 906;
                Functions.Pulse ( 50, READ_ERROR ) ; 
                } 
            
            __context__.SourceCodeLine = 908;
            FindClose ( ) ; 
            __context__.SourceCodeLine = 911;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( EndFileOperations() < 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 913;
                Print( "ERROR: Ending file ops.\r\n") ; 
                } 
            
            __context__.SourceCodeLine = 916;
            
            __context__.SourceCodeLine = 921;
            G_BWRITINGFILE = (ushort) ( 0 ) ; 
            
            return 0; // default return value (none specified in module)
            }
            
        private short SAVEEVENTS (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 943;
            CreateWait ( "SAVEWAIT" , 500 , SAVEWAIT_Callback ) ;
            __context__.SourceCodeLine = 947;
            RetimeWait ( (int)500, "SAVEWAIT" ) ; 
            
            return 0; // default return value (none specified in module)
            }
            
        public void SAVEWAIT_CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            __context__.SourceCodeLine = 945;
            WRITEEVENTFILE (  __context__  ) ; 
            
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    private ushort GETNORMALIZEDEVENTTIME (  SplusExecutionContext __context__, ushort IEVENTINDEX ) 
        { 
        ushort IBASETIME = 0;
        
        
        __context__.SourceCodeLine = 968;
        
            {
            int __SPLS_TMPVAR__SWTCH_2__ = ((int)G_EVENTS[ IEVENTINDEX ].TIMEBASE);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 0) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 972;
                    return (ushort)( G_EVENTS[ IEVENTINDEX ]._TIME) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 1) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 977;
                    return (ushort)( (G_EVENTS[ IEVENTINDEX ]._TIME + 720)) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 983;
                    IBASETIME = (ushort) ( ((MORNING_HOUR  .UshortValue * 60) + MORNING_MIN  .UshortValue) ) ; 
                    __context__.SourceCodeLine = 984;
                    return (ushort)( (IBASETIME + G_EVENTS[ IEVENTINDEX ]._TIME)) ; 
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 3) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 991;
                    IBASETIME = (ushort) ( ((NIGHT_HOUR  .UshortValue * 60) + NIGHT_MIN  .UshortValue) ) ; 
                    __context__.SourceCodeLine = 992;
                    return (ushort)( (IBASETIME + G_EVENTS[ IEVENTINDEX ]._TIME)) ; 
                    } 
                
                } 
                
            }
            
        
        
        return 0; // default return value (none specified in module)
        }
        
    private short COMPAREFILEDATEANDTIME (  SplusExecutionContext __context__, FILE_INFO FIFILE1 , FILE_INFO FIFILE2 ) 
        { 
        
        __context__.SourceCodeLine = 1018;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FIFILE1.iDate > FIFILE2.iDate ))  ) ) 
            {
            __context__.SourceCodeLine = 1019;
            return (short)( 1) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1020;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FIFILE1.iDate < FIFILE2.iDate ))  ) ) 
                {
                __context__.SourceCodeLine = 1021;
                return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                }
            
            else 
                { 
                __context__.SourceCodeLine = 1024;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FIFILE1.iTime > FIFILE2.iTime ))  ) ) 
                    {
                    __context__.SourceCodeLine = 1025;
                    return (short)( 1) ; 
                    }
                
                else 
                    {
                    __context__.SourceCodeLine = 1026;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( FIFILE1.iTime < FIFILE2.iTime ))  ) ) 
                        {
                        __context__.SourceCodeLine = 1027;
                        return (short)( Functions.ToSignedInteger( -( 1 ) )) ; 
                        }
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1029;
                        return (short)( 0) ; 
                        }
                    
                    }
                
                } 
            
            }
        
        
        return 0; // default return value (none specified in module)
        }
        
    private void VALIDATEEDITEVENTTIME (  SplusExecutionContext __context__ ) 
        { 
        
        __context__.SourceCodeLine = 1035;
        
            {
            int __SPLS_TMPVAR__SWTCH_3__ = ((int)G_EDITEVENT.TIMEBASE);
            
                { 
                if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 0) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1039;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_EDITEVENT._TIME < 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1041;
                        G_EDITEVENT . _TIME = (short) ( (720 - Mod( Functions.Abs( G_EDITEVENT._TIME ) , 720 )) ) ; 
                        __context__.SourceCodeLine = 1042;
                        G_EDITEVENT . TIMEBASE = (ushort) ( 1 ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1045;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_EDITEVENT._TIME >= 720 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1047;
                            G_EDITEVENT . _TIME = (short) ( Mod( G_EDITEVENT._TIME , 720 ) ) ; 
                            __context__.SourceCodeLine = 1048;
                            G_EDITEVENT . TIMEBASE = (ushort) ( 1 ) ; 
                            } 
                        
                        }
                    
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 1) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1054;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_EDITEVENT._TIME < 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1056;
                        G_EDITEVENT . _TIME = (short) ( (720 - Mod( Functions.Abs( G_EDITEVENT._TIME ) , 720 )) ) ; 
                        __context__.SourceCodeLine = 1057;
                        G_EDITEVENT . TIMEBASE = (ushort) ( 0 ) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 1060;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_EDITEVENT._TIME >= 720 ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1062;
                            G_EDITEVENT . _TIME = (short) ( Mod( G_EDITEVENT._TIME , 720 ) ) ; 
                            __context__.SourceCodeLine = 1063;
                            G_EDITEVENT . TIMEBASE = (ushort) ( 0 ) ; 
                            } 
                        
                        }
                    
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 2) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1069;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Abs( G_EDITEVENT._TIME ) > 360 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1071;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_EDITEVENT._TIME < 0 ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1072;
                            G_EDITEVENT . _TIME = (short) ( Functions.ToInteger( -( 360 ) ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1074;
                            G_EDITEVENT . _TIME = (short) ( 360 ) ; 
                            }
                        
                        } 
                    
                    } 
                
                else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 3) ) ) ) 
                    { 
                    __context__.SourceCodeLine = 1081;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Abs( G_EDITEVENT._TIME ) > 360 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 1083;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( G_EDITEVENT._TIME < 0 ))  ) ) 
                            {
                            __context__.SourceCodeLine = 1084;
                            G_EDITEVENT . _TIME = (short) ( Functions.ToInteger( -( 360 ) ) ) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 1086;
                            G_EDITEVENT . _TIME = (short) ( 360 ) ; 
                            }
                        
                        } 
                    
                    } 
                
                } 
                
            }
            
        
        
        }
        
    object HOUR_UP_OnPush_0 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 1096;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
                {
                __context__.SourceCodeLine = 1097;
                Functions.TerminateEvent (); 
                }
            
            __context__.SourceCodeLine = 1099;
            MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
            __context__.SourceCodeLine = 1100;
            G_EDITEVENT . _TIME = (short) ( (G_EDITEVENT._TIME + 60) ) ; 
            __context__.SourceCodeLine = 1101;
            VALIDATEEDITEVENTTIME (  __context__  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object HOUR_DOWN_OnPush_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1107;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1108;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 1110;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 1111;
        G_EDITEVENT . _TIME = (short) ( (G_EDITEVENT._TIME - 60) ) ; 
        __context__.SourceCodeLine = 1112;
        VALIDATEEDITEVENTTIME (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MINUTE_UP_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1117;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1118;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 1120;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 1121;
        G_EDITEVENT . _TIME = (short) ( (G_EDITEVENT._TIME + 1) ) ; 
        __context__.SourceCodeLine = 1122;
        VALIDATEEDITEVENTTIME (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object MINUTE_DOWN_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1128;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1129;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 1131;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 1132;
        G_EDITEVENT . _TIME = (short) ( (G_EDITEVENT._TIME - 1) ) ; 
        __context__.SourceCodeLine = 1133;
        VALIDATEEDITEVENTTIME (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object AM_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1139;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1140;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 1142;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 1143;
        G_EDITEVENT . TIMEBASE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1144;
        VALIDATEEDITEVENTTIME (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PM_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1149;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1150;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 1152;
        G_EDITEVENT . TIMEBASE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1153;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 1154;
        VALIDATEEDITEVENTTIME (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SUNRISE_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1159;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1160;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 1162;
        G_EDITEVENT . TIMEBASE = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1163;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 1164;
        VALIDATEEDITEVENTTIME (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SUNSET_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1169;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1170;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 1172;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 1173;
        G_EDITEVENT . TIMEBASE = (ushort) ( 3 ) ; 
        __context__.SourceCodeLine = 1174;
        VALIDATEEDITEVENTTIME (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object HOUR_UP_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1180;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1181;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 1183;
        UPDATEEDITEVENTTIME (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object EDIT_EVENT_OnChange_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1188;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EVENTS[ G_IEDITEVENT ].HIDDENSTATE == 0))  ) ) 
            {
            __context__.SourceCodeLine = 1189;
            G_IEDITEVENT = (ushort) ( EDIT_EVENT  .UshortValue ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object EDIT_EVENT_OnChange_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1197;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( G_IEDITEVENT ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)G_IMAXUSEDEVENT; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1199;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].FREE == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].HIDDENSTATE == 0) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1201;
                SETEDITEVENT (  __context__ , (ushort)( I )) ; 
                __context__.SourceCodeLine = 1202;
                break ; 
                } 
            
            __context__.SourceCodeLine = 1197;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object EDIT_FIRST_EVENT_OnPush_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1211;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)G_IMAXUSEDEVENT; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1213;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].FREE == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].HIDDENSTATE == 0) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1215;
                SETEDITEVENT (  __context__ , (ushort)( I )) ; 
                __context__.SourceCodeLine = 1216;
                break ; 
                } 
            
            __context__.SourceCodeLine = 1211;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object EDIT_LAST_EVENT_OnPush_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1225;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( G_IMAXUSEDEVENT ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)1; 
        int __FN_FORSTEP_VAL__1 = (int)Functions.ToLongInteger( -( 1 ) ); 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1227;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].FREE == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].HIDDENSTATE == 0) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1229;
                SETEDITEVENT (  __context__ , (ushort)( I )) ; 
                __context__.SourceCodeLine = 1230;
                break ; 
                } 
            
            __context__.SourceCodeLine = 1225;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object EDIT_NEXT_EVENT_OnPush_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1240;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( (G_IEDITEVENT + 1) ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)G_IMAXUSEDEVENT; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1242;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].FREE == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].HIDDENSTATE == 0) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1244;
                SETEDITEVENT (  __context__ , (ushort)( I )) ; 
                __context__.SourceCodeLine = 1245;
                break ; 
                } 
            
            __context__.SourceCodeLine = 1240;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object EDIT_PREV_EVENT_OnPush_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort I = 0;
        
        
        __context__.SourceCodeLine = 1255;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( (G_IEDITEVENT - 1) ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)1; 
        int __FN_FORSTEP_VAL__1 = (int)Functions.ToLongInteger( -( 1 ) ); 
        for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 1257;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].FREE == 0) ) && Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].HIDDENSTATE == 0) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1259;
                SETEDITEVENT (  __context__ , (ushort)( I )) ; 
                __context__.SourceCodeLine = 1260;
                break ; 
                } 
            
            __context__.SourceCodeLine = 1255;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SAVE_EDIT_EVENT_OnPush_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1267;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( G_IEDITEVENT <= 250 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( G_IEDITEVENT > 0 ) )) ))  ) ) 
            { 
            __context__.SourceCodeLine = 1269;
            
            __context__.SourceCodeLine = 1273;
            COPYEVENT (  __context__ , G_EDITEVENT,   ref  G_EVENTS[ G_IEDITEVENT ] ) ; 
            __context__.SourceCodeLine = 1275;
            SAVEEVENTS (  __context__  ) ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object SUSPEND_OnPush_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString STEMP;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, this );
        
        
        __context__.SourceCodeLine = 1283;
        MakeString ( STEMP , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 1284;
        G_EDITEVENT . LASTMODIFIED  .UpdateValue ( STEMP  ) ; 
        __context__.SourceCodeLine = 1285;
        G_EVENTS [ G_IEDITEVENT] . LASTMODIFIED  .UpdateValue ( STEMP  ) ; 
        __context__.SourceCodeLine = 1286;
        G_EDITEVENT . SUSPENDED = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1287;
        G_EVENTS [ G_IEDITEVENT] . SUSPENDED = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1288;
        UPDATEEDITEVENTSUSPENDED (  __context__  ) ; 
        __context__.SourceCodeLine = 1289;
        SAVEEVENTS (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object RESUME_OnPush_17 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString STEMP;
        STEMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, this );
        
        
        __context__.SourceCodeLine = 1296;
        MakeString ( STEMP , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 1297;
        G_EDITEVENT . LASTMODIFIED  .UpdateValue ( STEMP  ) ; 
        __context__.SourceCodeLine = 1298;
        G_EVENTS [ G_IEDITEVENT] . LASTMODIFIED  .UpdateValue ( STEMP  ) ; 
        __context__.SourceCodeLine = 1299;
        G_EDITEVENT . SUSPENDED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1300;
        G_EVENTS [ G_IEDITEVENT] . SUSPENDED = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1301;
        UPDATEEDITEVENTSUSPENDED (  __context__  ) ; 
        __context__.SourceCodeLine = 1302;
        SAVEEVENTS (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object EDIT_EVENT_FLAGS_OnPush_18 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort IFLAG = 0;
        
        
        __context__.SourceCodeLine = 1309;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (G_EDITEVENT.READONLY == 1))  ) ) 
            {
            __context__.SourceCodeLine = 1310;
            Functions.TerminateEvent (); 
            }
        
        __context__.SourceCodeLine = 1312;
        MakeString ( G_EDITEVENT . LASTMODIFIED , "{0:d2}{1:d2}{2:d}:{3:d2}{4:d2}{5:d2}", (short)Functions.GetMonthNum(), (short)Functions.GetDateNum(), (short)Functions.GetYearNum(), (short)Functions.GetHourNum(), (short)Functions.GetMinutesNum(), (short)Functions.GetSecondsNum()) ; 
        __context__.SourceCodeLine = 1314;
        IFLAG = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1316;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IFLAG <= 7 ))  ) ) 
            { 
            __context__.SourceCodeLine = 1318;
            G_EDITEVENT . VALIDDAYS = (ushort) ( TOGGLEBIT( __context__ , (ushort)( G_EDITEVENT.VALIDDAYS ) , (ushort)( (IFLAG - 1) ) ) ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 1323;
            G_EDITEVENT . VALIDMONTHS = (ushort) ( TOGGLEBIT( __context__ , (ushort)( G_EDITEVENT.VALIDMONTHS ) , (ushort)( (IFLAG - 8) ) ) ) ; 
            } 
        
        __context__.SourceCodeLine = 1326;
        UPDATEEDITEVENTFLAGS (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FILENAME__DOLLAR___OnChange_19 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1332;
        if ( Functions.TestForTrue  ( ( Functions.Length( FILENAME__DOLLAR__ ))  ) ) 
            {
            __context__.SourceCodeLine = 1333;
            G_BFILENAMEVALID = (ushort) ( 1 ) ; 
            }
        
        else 
            {
            __context__.SourceCodeLine = 1335;
            G_BFILENAMEVALID = (ushort) ( 0 ) ; 
            }
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

public override object FunctionMain (  object __obj__ ) 
    { 
    ushort ICURRENTTIME = 0;
    ushort ILASTCHECKEDTIME = 0;
    
    ushort ICURRENTDAYOFWEEK = 0;
    ushort ICURRENTMONTH = 0;
    
    ushort I = 0;
    
    short IERRCODE = 0;
    
    FILE_INFO FIDATAFILE;
    FIDATAFILE  = new FILE_INFO();
    FIDATAFILE .PopulateDefaults();
    
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 1349;
        G_IMONTHMASK [ 1] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1350;
        G_IMONTHMASK [ 2] = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1351;
        G_IMONTHMASK [ 3] = (ushort) ( 4 ) ; 
        __context__.SourceCodeLine = 1352;
        G_IMONTHMASK [ 4] = (ushort) ( 8 ) ; 
        __context__.SourceCodeLine = 1353;
        G_IMONTHMASK [ 5] = (ushort) ( 16 ) ; 
        __context__.SourceCodeLine = 1354;
        G_IMONTHMASK [ 6] = (ushort) ( 32 ) ; 
        __context__.SourceCodeLine = 1355;
        G_IMONTHMASK [ 7] = (ushort) ( 64 ) ; 
        __context__.SourceCodeLine = 1356;
        G_IMONTHMASK [ 8] = (ushort) ( 128 ) ; 
        __context__.SourceCodeLine = 1357;
        G_IMONTHMASK [ 9] = (ushort) ( 256 ) ; 
        __context__.SourceCodeLine = 1358;
        G_IMONTHMASK [ 10] = (ushort) ( 512 ) ; 
        __context__.SourceCodeLine = 1359;
        G_IMONTHMASK [ 11] = (ushort) ( 1024 ) ; 
        __context__.SourceCodeLine = 1360;
        G_IMONTHMASK [ 12] = (ushort) ( 2048 ) ; 
        __context__.SourceCodeLine = 1362;
        G_IDAYOFWEEKMASK [ 0] = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1363;
        G_IDAYOFWEEKMASK [ 1] = (ushort) ( 2 ) ; 
        __context__.SourceCodeLine = 1364;
        G_IDAYOFWEEKMASK [ 2] = (ushort) ( 4 ) ; 
        __context__.SourceCodeLine = 1365;
        G_IDAYOFWEEKMASK [ 3] = (ushort) ( 8 ) ; 
        __context__.SourceCodeLine = 1366;
        G_IDAYOFWEEKMASK [ 4] = (ushort) ( 16 ) ; 
        __context__.SourceCodeLine = 1367;
        G_IDAYOFWEEKMASK [ 5] = (ushort) ( 32 ) ; 
        __context__.SourceCodeLine = 1368;
        G_IDAYOFWEEKMASK [ 6] = (ushort) ( 64 ) ; 
        __context__.SourceCodeLine = 1382;
        G_IMAXUSEDEVENT = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1383;
        G_IEDITEVENT = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 1385;
        G_FIDATAFILE .  iTime = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1386;
        G_FIDATAFILE .  iDate = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1394;
        G_BFILENAMEVALID = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1396;
        G_BWRITINGFILE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1398;
        while ( Functions.TestForTrue  ( ( 1)  ) ) 
            { 
            __context__.SourceCodeLine = 1400;
            Functions.Delay (  (int) ( 1000 ) ) ; 
            __context__.SourceCodeLine = 1403;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( ENABLE  .Value ) && Functions.TestForTrue ( G_BFILENAMEVALID )) ) ) && Functions.TestForTrue ( Functions.Not( G_BWRITINGFILE ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 1409;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( StartFileOperations() >= 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1411;
                    IERRCODE = (short) ( FindFirst( FILENAME__DOLLAR__ , ref FIDATAFILE ) ) ; 
                    __context__.SourceCodeLine = 1412;
                    FindClose ( ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 1416;
                    Print( "StartFileOperations() failed.\r\n") ; 
                    } 
                
                __context__.SourceCodeLine = 1418;
                EndFileOperations ( ) ; 
                __context__.SourceCodeLine = 1420;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (COMPAREFILEDATEANDTIME( __context__ , FIDATAFILE , G_FIDATAFILE ) != 0))  ) ) 
                    {
                    __context__.SourceCodeLine = 1421;
                    LOADEVENTS (  __context__  ) ; 
                    }
                
                __context__.SourceCodeLine = 1423;
                ICURRENTTIME = (ushort) ( ((Functions.GetHourNum() * 60) + Functions.GetMinutesNum()) ) ; 
                __context__.SourceCodeLine = 1425;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (ILASTCHECKEDTIME != ICURRENTTIME))  ) ) 
                    { 
                    __context__.SourceCodeLine = 1427;
                    
                    __context__.SourceCodeLine = 1430;
                    ICURRENTDAYOFWEEK = (ushort) ( Functions.GetDayOfWeekNum() ) ; 
                    __context__.SourceCodeLine = 1431;
                    ICURRENTMONTH = (ushort) ( Functions.GetMonthNum() ) ; 
                    __context__.SourceCodeLine = 1434;
                    ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
                    ushort __FN_FOREND_VAL__1 = (ushort)G_IMAXUSEDEVENT; 
                    int __FN_FORSTEP_VAL__1 = (int)1; 
                    for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                        { 
                        __context__.SourceCodeLine = 1437;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.Not( G_EVENTS[ I ].SUSPENDED ) ) && Functions.TestForTrue ( Functions.BoolToInt (G_EVENTS[ I ].FREE == 0) )) ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 1439;
                            
                            __context__.SourceCodeLine = 1442;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (GETNORMALIZEDEVENTTIME( __context__ , (ushort)( I ) ) == ICURRENTTIME))  ) ) 
                                { 
                                __context__.SourceCodeLine = 1444;
                                if ( Functions.TestForTrue  ( ( EVENTISVALIDTODAY( __context__ , (ushort)( I ) , (ushort)( ICURRENTDAYOFWEEK ) , (ushort)( ICURRENTMONTH ) ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 1446;
                                    Functions.Pulse ( 50, EVENT_DUE [ I] ) ; 
                                    __context__.SourceCodeLine = 1447;
                                    MESSAGE__DOLLAR__  .UpdateValue ( "Fired event " + G_EVENTS [ I] . NAME  ) ; 
                                    __context__.SourceCodeLine = 1448;
                                    
                                    } 
                                
                                } 
                            
                            } 
                        
                        __context__.SourceCodeLine = 1434;
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 1457;
                ILASTCHECKEDTIME = (ushort) ( ICURRENTTIME ) ; 
                __context__.SourceCodeLine = 1459;
                Functions.Delay (  (int) ( 1000 ) ) ; 
                __context__.SourceCodeLine = 1403;
                } 
            
            __context__.SourceCodeLine = 1398;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    G_IMONTHMASK  = new ushort[ 13 ];
    G_IDAYOFWEEKMASK  = new ushort[ 7 ];
    G_EDITEVENT  = new EVENTINFO( this, true );
    G_EDITEVENT .PopulateCustomAttributeList( false );
    G_FIDATAFILE  = new FILE_INFO();
    G_FIDATAFILE .PopulateDefaults();
    G_EVENTS  = new EVENTINFO[ 251 ];
    for( uint i = 0; i < 251; i++ )
    {
        G_EVENTS [i] = new EVENTINFO( this, true );
        G_EVENTS [i].PopulateCustomAttributeList( false );
        
    }
    
    ENABLE = new Crestron.Logos.SplusObjects.DigitalInput( ENABLE__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLE__DigitalInput__, ENABLE );
    
    SAVE_EDIT_EVENT = new Crestron.Logos.SplusObjects.DigitalInput( SAVE_EDIT_EVENT__DigitalInput__, this );
    m_DigitalInputList.Add( SAVE_EDIT_EVENT__DigitalInput__, SAVE_EDIT_EVENT );
    
    REVERT_EDIT_EVENT = new Crestron.Logos.SplusObjects.DigitalInput( REVERT_EDIT_EVENT__DigitalInput__, this );
    m_DigitalInputList.Add( REVERT_EDIT_EVENT__DigitalInput__, REVERT_EDIT_EVENT );
    
    EDIT_FIRST_EVENT = new Crestron.Logos.SplusObjects.DigitalInput( EDIT_FIRST_EVENT__DigitalInput__, this );
    m_DigitalInputList.Add( EDIT_FIRST_EVENT__DigitalInput__, EDIT_FIRST_EVENT );
    
    EDIT_NEXT_EVENT = new Crestron.Logos.SplusObjects.DigitalInput( EDIT_NEXT_EVENT__DigitalInput__, this );
    m_DigitalInputList.Add( EDIT_NEXT_EVENT__DigitalInput__, EDIT_NEXT_EVENT );
    
    EDIT_PREV_EVENT = new Crestron.Logos.SplusObjects.DigitalInput( EDIT_PREV_EVENT__DigitalInput__, this );
    m_DigitalInputList.Add( EDIT_PREV_EVENT__DigitalInput__, EDIT_PREV_EVENT );
    
    EDIT_LAST_EVENT = new Crestron.Logos.SplusObjects.DigitalInput( EDIT_LAST_EVENT__DigitalInput__, this );
    m_DigitalInputList.Add( EDIT_LAST_EVENT__DigitalInput__, EDIT_LAST_EVENT );
    
    HOUR_UP = new Crestron.Logos.SplusObjects.DigitalInput( HOUR_UP__DigitalInput__, this );
    m_DigitalInputList.Add( HOUR_UP__DigitalInput__, HOUR_UP );
    
    HOUR_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( HOUR_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( HOUR_DOWN__DigitalInput__, HOUR_DOWN );
    
    MINUTE_UP = new Crestron.Logos.SplusObjects.DigitalInput( MINUTE_UP__DigitalInput__, this );
    m_DigitalInputList.Add( MINUTE_UP__DigitalInput__, MINUTE_UP );
    
    MINUTE_DOWN = new Crestron.Logos.SplusObjects.DigitalInput( MINUTE_DOWN__DigitalInput__, this );
    m_DigitalInputList.Add( MINUTE_DOWN__DigitalInput__, MINUTE_DOWN );
    
    AM = new Crestron.Logos.SplusObjects.DigitalInput( AM__DigitalInput__, this );
    m_DigitalInputList.Add( AM__DigitalInput__, AM );
    
    PM = new Crestron.Logos.SplusObjects.DigitalInput( PM__DigitalInput__, this );
    m_DigitalInputList.Add( PM__DigitalInput__, PM );
    
    SUNRISE = new Crestron.Logos.SplusObjects.DigitalInput( SUNRISE__DigitalInput__, this );
    m_DigitalInputList.Add( SUNRISE__DigitalInput__, SUNRISE );
    
    SUNSET = new Crestron.Logos.SplusObjects.DigitalInput( SUNSET__DigitalInput__, this );
    m_DigitalInputList.Add( SUNSET__DigitalInput__, SUNSET );
    
    SUSPEND = new Crestron.Logos.SplusObjects.DigitalInput( SUSPEND__DigitalInput__, this );
    m_DigitalInputList.Add( SUSPEND__DigitalInput__, SUSPEND );
    
    RESUME = new Crestron.Logos.SplusObjects.DigitalInput( RESUME__DigitalInput__, this );
    m_DigitalInputList.Add( RESUME__DigitalInput__, RESUME );
    
    EDIT_EVENT_FLAGS = new InOutArray<DigitalInput>( 19, this );
    for( uint i = 0; i < 19; i++ )
    {
        EDIT_EVENT_FLAGS[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( EDIT_EVENT_FLAGS__DigitalInput__ + i, EDIT_EVENT_FLAGS__DigitalInput__, this );
        m_DigitalInputList.Add( EDIT_EVENT_FLAGS__DigitalInput__ + i, EDIT_EVENT_FLAGS[i+1] );
    }
    
    READ_ERROR = new Crestron.Logos.SplusObjects.DigitalOutput( READ_ERROR__DigitalOutput__, this );
    m_DigitalOutputList.Add( READ_ERROR__DigitalOutput__, READ_ERROR );
    
    WRITE_ERROR = new Crestron.Logos.SplusObjects.DigitalOutput( WRITE_ERROR__DigitalOutput__, this );
    m_DigitalOutputList.Add( WRITE_ERROR__DigitalOutput__, WRITE_ERROR );
    
    EDIT_EVENT_SUSPENDED = new Crestron.Logos.SplusObjects.DigitalOutput( EDIT_EVENT_SUSPENDED__DigitalOutput__, this );
    m_DigitalOutputList.Add( EDIT_EVENT_SUSPENDED__DigitalOutput__, EDIT_EVENT_SUSPENDED );
    
    EDIT_EVENT_READONLY = new Crestron.Logos.SplusObjects.DigitalOutput( EDIT_EVENT_READONLY__DigitalOutput__, this );
    m_DigitalOutputList.Add( EDIT_EVENT_READONLY__DigitalOutput__, EDIT_EVENT_READONLY );
    
    EVENT_DUE = new InOutArray<DigitalOutput>( 250, this );
    for( uint i = 0; i < 250; i++ )
    {
        EVENT_DUE[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( EVENT_DUE__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( EVENT_DUE__DigitalOutput__ + i, EVENT_DUE[i+1] );
    }
    
    EDIT_EVENT = new Crestron.Logos.SplusObjects.AnalogInput( EDIT_EVENT__AnalogSerialInput__, this );
    m_AnalogInputList.Add( EDIT_EVENT__AnalogSerialInput__, EDIT_EVENT );
    
    MORNING_HOUR = new Crestron.Logos.SplusObjects.AnalogInput( MORNING_HOUR__AnalogSerialInput__, this );
    m_AnalogInputList.Add( MORNING_HOUR__AnalogSerialInput__, MORNING_HOUR );
    
    MORNING_MIN = new Crestron.Logos.SplusObjects.AnalogInput( MORNING_MIN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( MORNING_MIN__AnalogSerialInput__, MORNING_MIN );
    
    NIGHT_HOUR = new Crestron.Logos.SplusObjects.AnalogInput( NIGHT_HOUR__AnalogSerialInput__, this );
    m_AnalogInputList.Add( NIGHT_HOUR__AnalogSerialInput__, NIGHT_HOUR );
    
    NIGHT_MIN = new Crestron.Logos.SplusObjects.AnalogInput( NIGHT_MIN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( NIGHT_MIN__AnalogSerialInput__, NIGHT_MIN );
    
    EDIT_EVENT_NUMBER = new Crestron.Logos.SplusObjects.AnalogOutput( EDIT_EVENT_NUMBER__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( EDIT_EVENT_NUMBER__AnalogSerialOutput__, EDIT_EVENT_NUMBER );
    
    EDIT_EVENT_TIMEBASE = new Crestron.Logos.SplusObjects.AnalogOutput( EDIT_EVENT_TIMEBASE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( EDIT_EVENT_TIMEBASE__AnalogSerialOutput__, EDIT_EVENT_TIMEBASE );
    
    EDIT_EVENT_VALID_DAYS = new Crestron.Logos.SplusObjects.AnalogOutput( EDIT_EVENT_VALID_DAYS__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( EDIT_EVENT_VALID_DAYS__AnalogSerialOutput__, EDIT_EVENT_VALID_DAYS );
    
    EDIT_EVENT_VALID_MONTHS = new Crestron.Logos.SplusObjects.AnalogOutput( EDIT_EVENT_VALID_MONTHS__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( EDIT_EVENT_VALID_MONTHS__AnalogSerialOutput__, EDIT_EVENT_VALID_MONTHS );
    
    FILENAME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringInput( FILENAME__DOLLAR____AnalogSerialInput__, 255, this );
    m_StringInputList.Add( FILENAME__DOLLAR____AnalogSerialInput__, FILENAME__DOLLAR__ );
    
    EDIT_EVENT_NAME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( EDIT_EVENT_NAME__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( EDIT_EVENT_NAME__DOLLAR____AnalogSerialOutput__, EDIT_EVENT_NAME__DOLLAR__ );
    
    EDIT_EVENT_TIME__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( EDIT_EVENT_TIME__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( EDIT_EVENT_TIME__DOLLAR____AnalogSerialOutput__, EDIT_EVENT_TIME__DOLLAR__ );
    
    MESSAGE__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( MESSAGE__DOLLAR____AnalogSerialOutput__, this );
    m_StringOutputList.Add( MESSAGE__DOLLAR____AnalogSerialOutput__, MESSAGE__DOLLAR__ );
    
    SAVEWAIT_Callback = new WaitFunction( SAVEWAIT_CallbackFn );
    
    HOUR_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_0, false ) );
    HOUR_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_DOWN_OnPush_1, false ) );
    MINUTE_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( MINUTE_UP_OnPush_2, false ) );
    MINUTE_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( MINUTE_DOWN_OnPush_3, false ) );
    AM.OnDigitalPush.Add( new InputChangeHandlerWrapper( AM_OnPush_4, false ) );
    PM.OnDigitalPush.Add( new InputChangeHandlerWrapper( PM_OnPush_5, false ) );
    SUNRISE.OnDigitalPush.Add( new InputChangeHandlerWrapper( SUNRISE_OnPush_6, false ) );
    SUNSET.OnDigitalPush.Add( new InputChangeHandlerWrapper( SUNSET_OnPush_7, false ) );
    HOUR_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_8, false ) );
    HOUR_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_8, false ) );
    MINUTE_UP.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_8, false ) );
    MINUTE_DOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_8, false ) );
    AM.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_8, false ) );
    PM.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_8, false ) );
    SUNRISE.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_8, false ) );
    SUNSET.OnDigitalPush.Add( new InputChangeHandlerWrapper( HOUR_UP_OnPush_8, false ) );
    EDIT_EVENT.OnAnalogChange.Add( new InputChangeHandlerWrapper( EDIT_EVENT_OnChange_9, false ) );
    EDIT_EVENT.OnAnalogChange.Add( new InputChangeHandlerWrapper( EDIT_EVENT_OnChange_10, false ) );
    REVERT_EDIT_EVENT.OnDigitalPush.Add( new InputChangeHandlerWrapper( EDIT_EVENT_OnChange_10, false ) );
    EDIT_FIRST_EVENT.OnDigitalPush.Add( new InputChangeHandlerWrapper( EDIT_FIRST_EVENT_OnPush_11, false ) );
    EDIT_LAST_EVENT.OnDigitalPush.Add( new InputChangeHandlerWrapper( EDIT_LAST_EVENT_OnPush_12, false ) );
    EDIT_NEXT_EVENT.OnDigitalPush.Add( new InputChangeHandlerWrapper( EDIT_NEXT_EVENT_OnPush_13, false ) );
    EDIT_PREV_EVENT.OnDigitalPush.Add( new InputChangeHandlerWrapper( EDIT_PREV_EVENT_OnPush_14, false ) );
    SAVE_EDIT_EVENT.OnDigitalPush.Add( new InputChangeHandlerWrapper( SAVE_EDIT_EVENT_OnPush_15, false ) );
    SUSPEND.OnDigitalPush.Add( new InputChangeHandlerWrapper( SUSPEND_OnPush_16, false ) );
    RESUME.OnDigitalPush.Add( new InputChangeHandlerWrapper( RESUME_OnPush_17, false ) );
    for( uint i = 0; i < 19; i++ )
        EDIT_EVENT_FLAGS[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( EDIT_EVENT_FLAGS_OnPush_18, false ) );
        
    FILENAME__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( FILENAME__DOLLAR___OnChange_19, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public CrestronModuleClass_EVENTSKED2_V12 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction SAVEWAIT_Callback;


const uint ENABLE__DigitalInput__ = 0;
const uint SAVE_EDIT_EVENT__DigitalInput__ = 1;
const uint REVERT_EDIT_EVENT__DigitalInput__ = 2;
const uint EDIT_FIRST_EVENT__DigitalInput__ = 3;
const uint EDIT_NEXT_EVENT__DigitalInput__ = 4;
const uint EDIT_PREV_EVENT__DigitalInput__ = 5;
const uint EDIT_LAST_EVENT__DigitalInput__ = 6;
const uint HOUR_UP__DigitalInput__ = 7;
const uint HOUR_DOWN__DigitalInput__ = 8;
const uint MINUTE_UP__DigitalInput__ = 9;
const uint MINUTE_DOWN__DigitalInput__ = 10;
const uint AM__DigitalInput__ = 11;
const uint PM__DigitalInput__ = 12;
const uint SUNRISE__DigitalInput__ = 13;
const uint SUNSET__DigitalInput__ = 14;
const uint SUSPEND__DigitalInput__ = 15;
const uint RESUME__DigitalInput__ = 16;
const uint EDIT_EVENT_FLAGS__DigitalInput__ = 17;
const uint EDIT_EVENT__AnalogSerialInput__ = 0;
const uint MORNING_HOUR__AnalogSerialInput__ = 1;
const uint MORNING_MIN__AnalogSerialInput__ = 2;
const uint NIGHT_HOUR__AnalogSerialInput__ = 3;
const uint NIGHT_MIN__AnalogSerialInput__ = 4;
const uint FILENAME__DOLLAR____AnalogSerialInput__ = 5;
const uint READ_ERROR__DigitalOutput__ = 0;
const uint WRITE_ERROR__DigitalOutput__ = 1;
const uint EDIT_EVENT_SUSPENDED__DigitalOutput__ = 2;
const uint EDIT_EVENT_READONLY__DigitalOutput__ = 3;
const uint EVENT_DUE__DigitalOutput__ = 4;
const uint EDIT_EVENT_NUMBER__AnalogSerialOutput__ = 0;
const uint EDIT_EVENT_TIMEBASE__AnalogSerialOutput__ = 1;
const uint EDIT_EVENT_VALID_DAYS__AnalogSerialOutput__ = 2;
const uint EDIT_EVENT_VALID_MONTHS__AnalogSerialOutput__ = 3;
const uint EDIT_EVENT_NAME__DOLLAR____AnalogSerialOutput__ = 4;
const uint EDIT_EVENT_TIME__DOLLAR____AnalogSerialOutput__ = 5;
const uint MESSAGE__DOLLAR____AnalogSerialOutput__ = 6;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}

[SplusStructAttribute(-1, true, false)]
public class EVENTINFO : SplusStructureBase
{

    [SplusStructAttribute(0, false, false)]
    public CrestronString  NAME;
    
    [SplusStructAttribute(1, false, false)]
    public ushort  TIMEBASE = 0;
    
    [SplusStructAttribute(2, false, false)]
    public short  _TIME = 0;
    
    [SplusStructAttribute(3, false, false)]
    public ushort  VALIDDAYS = 0;
    
    [SplusStructAttribute(4, false, false)]
    public ushort  VALIDMONTHS = 0;
    
    [SplusStructAttribute(5, false, false)]
    public ushort  FREE = 0;
    
    [SplusStructAttribute(6, false, false)]
    public ushort  SUSPENDED = 0;
    
    [SplusStructAttribute(7, false, false)]
    public ushort  HIDDENSTATE = 0;
    
    [SplusStructAttribute(8, false, false)]
    public ushort  READONLY = 0;
    
    [SplusStructAttribute(9, false, false)]
    public CrestronString  LASTMODIFIED;
    
    [SplusStructAttribute(10, false, false)]
    public CrestronString  USERDATA;
    
    
    public EVENTINFO( SplusObject __caller__, bool bIsStructureVolatile ) : base ( __caller__, bIsStructureVolatile )
    {
        NAME  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, Owner );
        LASTMODIFIED  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 16, Owner );
        USERDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 50, Owner );
        
        
    }
    
}

}
