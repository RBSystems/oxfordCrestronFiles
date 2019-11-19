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

namespace UserModule_SOMFY_SDN2_0_MOTOR_CONTROL_V1_0
{
    public class UserModuleClass_SOMFY_SDN2_0_MOTOR_CONTROL_V1_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput THREEBUTTONUP;
        Crestron.Logos.SplusObjects.DigitalInput THREEBUTTONDOWN;
        Crestron.Logos.SplusObjects.DigitalInput THREEBUTTONSTOP;
        Crestron.Logos.SplusObjects.DigitalInput TWOBUTTONUP;
        Crestron.Logos.SplusObjects.DigitalInput TWOBUTTONDOWN;
        Crestron.Logos.SplusObjects.DigitalInput PRESETUP;
        Crestron.Logos.SplusObjects.DigitalInput PRESETDOWN;
        Crestron.Logos.SplusObjects.DigitalInput POLL;
        Crestron.Logos.SplusObjects.AnalogInput GOTOPERCENTDOWN;
        Crestron.Logos.SplusObjects.AnalogInput GOTOPRESET;
        Crestron.Logos.SplusObjects.BufferInput FROMQUEUEMODULE;
        Crestron.Logos.SplusObjects.AnalogOutput CURRENTPOSITION;
        Crestron.Logos.SplusObjects.AnalogOutput CURRENTPRESET;
        Crestron.Logos.SplusObjects.AnalogOutput CURTAINCONTROLLERPOSITION;
        Crestron.Logos.SplusObjects.StringOutput TOQUEUEMODULE;
        StringParameter PARAMCRESTRONADDRESS;
        StringParameter PARAMMOTORADDRESS;
        ushort POLLCOUNTER = 0;
        ushort MAXPOLLCOUNT = 0;
        uint REQUESTEDPOSITION = 0;
        ushort REQUESTEDPOSITIONMAX = 0;
        ushort REQUESTEDPOSITIONMIN = 0;
        private CrestronString GETCHECKSUM (  SplusExecutionContext __context__, CrestronString PARAMDATA ) 
            { 
            CrestronString RETURNSTRING;
            RETURNSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 2, this );
            
            ushort A = 0;
            ushort TEMPCHECKSUM = 0;
            
            
            __context__.SourceCodeLine = 99;
            RETURNSTRING  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 100;
            TEMPCHECKSUM = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 101;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)Functions.Length( PARAMDATA ); 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 103;
                TEMPCHECKSUM = (ushort) ( (TEMPCHECKSUM + Byte( PARAMDATA , (int)( A ) )) ) ; 
                __context__.SourceCodeLine = 101;
                } 
            
            __context__.SourceCodeLine = 105;
            MakeString ( RETURNSTRING , "{0}{1}", Functions.Chr (  (int) ( Functions.High( (ushort) TEMPCHECKSUM ) ) ) , Functions.Chr (  (int) ( Functions.Low( (ushort) TEMPCHECKSUM ) ) ) ) ; 
            __context__.SourceCodeLine = 106;
            return ( RETURNSTRING ) ; 
            
            }
            
        private CrestronString GETMOTORADDRESS (  SplusExecutionContext __context__ ) 
            { 
            CrestronString RETURNSTRING;
            RETURNSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
            
            ushort [] TEMPBYTES;
            ushort A = 0;
            TEMPBYTES  = new ushort[ 4 ];
            
            
            __context__.SourceCodeLine = 114;
            RETURNSTRING  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 115;
            TEMPBYTES [ 3] = (ushort) ( Functions.HextoI( Functions.Right( PARAMMOTORADDRESS  , (int)( 2 ) ) ) ) ; 
            __context__.SourceCodeLine = 116;
            TEMPBYTES [ 2] = (ushort) ( Functions.HextoI( Functions.Mid( PARAMMOTORADDRESS  , (int)( 3 ) , (int)( 2 ) ) ) ) ; 
            __context__.SourceCodeLine = 117;
            TEMPBYTES [ 1] = (ushort) ( Functions.HextoI( Functions.Left( PARAMMOTORADDRESS  , (int)( 2 ) ) ) ) ; 
            __context__.SourceCodeLine = 118;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 3 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)1; 
            int __FN_FORSTEP_VAL__1 = (int)Functions.ToLongInteger( -( 1 ) ); 
            for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 120;
                MakeString ( RETURNSTRING , "{0}{1}", RETURNSTRING , Functions.Chr (  (int) ( (255 - TEMPBYTES[ A ]) ) ) ) ; 
                __context__.SourceCodeLine = 118;
                } 
            
            __context__.SourceCodeLine = 122;
            return ( RETURNSTRING ) ; 
            
            }
            
        private void POLLPOSITION (  SplusExecutionContext __context__ ) 
            { 
            CrestronString TEMPCOMMAND;
            TEMPCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
            
            
            __context__.SourceCodeLine = 129;
            MakeString ( TEMPCOMMAND , "\u00F3\u00F4\u00FF{0}{1}", PARAMCRESTRONADDRESS , GETMOTORADDRESS (  __context__  ) ) ; 
            __context__.SourceCodeLine = 130;
            MakeString ( TOQUEUEMODULE , "{0}{1}\u000D\u000A", TEMPCOMMAND , GETCHECKSUM (  __context__ , TEMPCOMMAND) ) ; 
            __context__.SourceCodeLine = 131;
            POLLCOUNTER = (ushort) ( (POLLCOUNTER + 1) ) ; 
            __context__.SourceCodeLine = 132;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( MAXPOLLCOUNT > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( POLLCOUNTER < MAXPOLLCOUNT ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 134;
                CreateWait ( "POLLWAIT" , 25 , POLLWAIT_Callback ) ;
                } 
            
            
            }
            
        public void POLLWAIT_CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            __context__.SourceCodeLine = 136;
            POLLPOSITION (  __context__  ) ; 
            
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    private CrestronString PROCESSDATA (  SplusExecutionContext __context__, CrestronString PARAMDATA ) 
        { 
        CrestronString RETURNSTRING;
        CrestronString TEMPDATA;
        CrestronString TEMPCALCASCII;
        RETURNSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
        TEMPDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
        TEMPCALCASCII  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
        
        ushort TEMPNUMBER = 0;
        ushort TEMPPOSITION = 0;
        ushort TEMPPRESETNUMBER = 0;
        ushort TEMPINVERTEDPOSITION = 0;
        
        uint TEMPCALC = 0;
        uint TEMPINVERTEDCALC = 0;
        
        
        __context__.SourceCodeLine = 147;
        TEMPNUMBER = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 148;
        RETURNSTRING  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 149;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "Send Name" , PARAMDATA ) > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 151;
            TEMPNUMBER = (ushort) ( Functions.Atoi( PARAMDATA ) ) ; 
            __context__.SourceCodeLine = 152;
            MakeString ( RETURNSTRING , "Send Name {0:d} = {1}\u000D\u000A", (short)TEMPNUMBER, GETMOTORADDRESS (  __context__  ) ) ; 
            __context__.SourceCodeLine = 153;
            MAXPOLLCOUNT = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 154;
            POLLPOSITION (  __context__  ) ; 
            } 
        
        else 
            {
            __context__.SourceCodeLine = 156;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Mid( PARAMDATA , (int)( 4 ) , (int)( 3 ) ) == GETMOTORADDRESS( __context__ )) ) && Functions.TestForTrue ( Functions.BoolToInt (Functions.Left( PARAMDATA , (int)( 3 ) ) == "\u00F2\u00EF\u008F") )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 158;
                TEMPDATA  .UpdateValue ( Functions.Mid ( PARAMDATA ,  (int) ( 10 ) ,  (int) ( 5 ) )  ) ; 
                __context__.SourceCodeLine = 159;
                TEMPPRESETNUMBER = (ushort) ( (255 - Byte( TEMPDATA , (int)( 5 ) )) ) ; 
                __context__.SourceCodeLine = 160;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TEMPPRESETNUMBER > 16 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 162;
                    TEMPPRESETNUMBER = (ushort) ( 0 ) ; 
                    } 
                
                __context__.SourceCodeLine = 164;
                TEMPPOSITION = (ushort) ( (255 - Byte( TEMPDATA , (int)( 3 ) )) ) ; 
                __context__.SourceCodeLine = 165;
                TEMPINVERTEDPOSITION = (ushort) ( (100 - TEMPPOSITION) ) ; 
                __context__.SourceCodeLine = 166;
                TEMPCALC = (uint) ( (65535 * TEMPPOSITION) ) ; 
                __context__.SourceCodeLine = 167;
                TEMPINVERTEDCALC = (uint) ( (65535 * TEMPINVERTEDPOSITION) ) ; 
                __context__.SourceCodeLine = 168;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Mod( TEMPCALC , 100 ) >= 50 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 170;
                    MakeString ( TEMPCALCASCII , "{0:d}", (int)((TEMPCALC / 100) + 1)) ; 
                    __context__.SourceCodeLine = 171;
                    TEMPPOSITION = (ushort) ( Functions.Atoi( TEMPCALCASCII ) ) ; 
                    __context__.SourceCodeLine = 172;
                    MakeString ( TEMPCALCASCII , "{0:d}", (int)((TEMPINVERTEDCALC / 100) + 1)) ; 
                    __context__.SourceCodeLine = 173;
                    TEMPINVERTEDPOSITION = (ushort) ( Functions.Atoi( TEMPCALCASCII ) ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 177;
                    MakeString ( TEMPCALCASCII , "{0:d}", (int)(TEMPCALC / 100)) ; 
                    __context__.SourceCodeLine = 178;
                    TEMPPOSITION = (ushort) ( Functions.Atoi( TEMPCALCASCII ) ) ; 
                    __context__.SourceCodeLine = 179;
                    MakeString ( TEMPCALCASCII , "{0:d}", (int)(TEMPINVERTEDCALC / 100)) ; 
                    __context__.SourceCodeLine = 180;
                    TEMPINVERTEDPOSITION = (ushort) ( Functions.Atoi( TEMPCALCASCII ) ) ; 
                    } 
                
                __context__.SourceCodeLine = 182;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( REQUESTEDPOSITION <= 65535 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( TEMPPOSITION <= REQUESTEDPOSITIONMAX ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( TEMPPOSITION >= REQUESTEDPOSITIONMIN ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 184;
                    POLLCOUNTER = (ushort) ( (MAXPOLLCOUNT - 5) ) ; 
                    __context__.SourceCodeLine = 185;
                    REQUESTEDPOSITION = (uint) ( 65536 ) ; 
                    __context__.SourceCodeLine = 186;
                    REQUESTEDPOSITIONMAX = (ushort) ( 65535 ) ; 
                    __context__.SourceCodeLine = 187;
                    REQUESTEDPOSITIONMIN = (ushort) ( 0 ) ; 
                    } 
                
                __context__.SourceCodeLine = 189;
                CURRENTPOSITION  .Value = (ushort) ( TEMPPOSITION ) ; 
                __context__.SourceCodeLine = 190;
                CURTAINCONTROLLERPOSITION  .Value = (ushort) ( TEMPINVERTEDPOSITION ) ; 
                __context__.SourceCodeLine = 191;
                CURRENTPRESET  .Value = (ushort) ( TEMPPRESETNUMBER ) ; 
                } 
            
            }
        
        __context__.SourceCodeLine = 193;
        return ( RETURNSTRING ) ; 
        
        }
        
    object THREEBUTTONUP_OnPush_0 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            CrestronString TEMPCOMMAND;
            TEMPCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
            
            
            __context__.SourceCodeLine = 203;
            POLLCOUNTER = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 204;
            MAXPOLLCOUNT = (ushort) ( 40 ) ; 
            __context__.SourceCodeLine = 205;
            MakeString ( TEMPCOMMAND , "\u00FC\u00F0\u00FF{0}{1}\u00FE\u00FF\u00FF\u00FF", PARAMCRESTRONADDRESS , GETMOTORADDRESS (  __context__  ) ) ; 
            __context__.SourceCodeLine = 206;
            MakeString ( TOQUEUEMODULE , "{0}{1}\u000D\u000A", TEMPCOMMAND , GETCHECKSUM (  __context__ , TEMPCOMMAND) ) ; 
            __context__.SourceCodeLine = 207;
            POLLPOSITION (  __context__  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object THREEBUTTONDOWN_OnPush_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString TEMPCOMMAND;
        TEMPCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
        
        
        __context__.SourceCodeLine = 214;
        POLLCOUNTER = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 215;
        MAXPOLLCOUNT = (ushort) ( 40 ) ; 
        __context__.SourceCodeLine = 216;
        MakeString ( TEMPCOMMAND , "\u00FC\u00F0\u00FF{0}{1}\u00FF\u00FF\u00FF\u00FF", PARAMCRESTRONADDRESS , GETMOTORADDRESS (  __context__  ) ) ; 
        __context__.SourceCodeLine = 217;
        MakeString ( TOQUEUEMODULE , "{0}{1}\u000D\u000A", TEMPCOMMAND , GETCHECKSUM (  __context__ , TEMPCOMMAND) ) ; 
        __context__.SourceCodeLine = 218;
        POLLPOSITION (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object THREEBUTTONSTOP_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString TEMPCOMMAND;
        TEMPCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
        
        
        __context__.SourceCodeLine = 225;
        POLLCOUNTER = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 226;
        MAXPOLLCOUNT = (ushort) ( 10 ) ; 
        __context__.SourceCodeLine = 227;
        MakeString ( TEMPCOMMAND , "\u00FD\u00F3\u00FF{0}{1}\u00FF", PARAMCRESTRONADDRESS , GETMOTORADDRESS (  __context__  ) ) ; 
        __context__.SourceCodeLine = 228;
        MakeString ( TOQUEUEMODULE , "{0}{1}\u000D\u000A", TEMPCOMMAND , GETCHECKSUM (  __context__ , TEMPCOMMAND) ) ; 
        __context__.SourceCodeLine = 229;
        POLLPOSITION (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TWOBUTTONUP_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString TEMPCOMMAND;
        TEMPCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
        
        
        __context__.SourceCodeLine = 236;
        POLLCOUNTER = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 237;
        MAXPOLLCOUNT = (ushort) ( 40 ) ; 
        __context__.SourceCodeLine = 238;
        MakeString ( TEMPCOMMAND , "\u00FC\u00F0\u00FF{0}{1}\u00FE\u00FF\u00FF\u00FF", PARAMCRESTRONADDRESS , GETMOTORADDRESS (  __context__  ) ) ; 
        __context__.SourceCodeLine = 239;
        MakeString ( TOQUEUEMODULE , "{0}{1}\u000D\u000A", TEMPCOMMAND , GETCHECKSUM (  __context__ , TEMPCOMMAND) ) ; 
        __context__.SourceCodeLine = 240;
        POLLPOSITION (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TWOBUTTONDOWN_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString TEMPCOMMAND;
        TEMPCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
        
        
        __context__.SourceCodeLine = 247;
        POLLCOUNTER = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 248;
        MAXPOLLCOUNT = (ushort) ( 40 ) ; 
        __context__.SourceCodeLine = 249;
        MakeString ( TEMPCOMMAND , "\u00FC\u00F0\u00FF{0}{1}\u00FF\u00FF\u00FF\u00FF", PARAMCRESTRONADDRESS , GETMOTORADDRESS (  __context__  ) ) ; 
        __context__.SourceCodeLine = 250;
        MakeString ( TOQUEUEMODULE , "{0}{1}\u000D\u000A", TEMPCOMMAND , GETCHECKSUM (  __context__ , TEMPCOMMAND) ) ; 
        __context__.SourceCodeLine = 251;
        POLLPOSITION (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object TWOBUTTONUP_OnRelease_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString TEMPCOMMAND;
        TEMPCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
        
        
        __context__.SourceCodeLine = 258;
        POLLCOUNTER = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 259;
        MAXPOLLCOUNT = (ushort) ( 10 ) ; 
        __context__.SourceCodeLine = 260;
        MakeString ( TEMPCOMMAND , "\u00FD\u00F3\u00FF{0}{1}\u00FF", PARAMCRESTRONADDRESS , GETMOTORADDRESS (  __context__  ) ) ; 
        __context__.SourceCodeLine = 261;
        MakeString ( TOQUEUEMODULE , "{0}{1}\u000D\u000A", TEMPCOMMAND , GETCHECKSUM (  __context__ , TEMPCOMMAND) ) ; 
        __context__.SourceCodeLine = 262;
        POLLPOSITION (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object GOTOPERCENTDOWN_OnChange_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString TEMPCOMMAND;
        CrestronString TEMPSTRING;
        TEMPCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
        TEMPSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5, this );
        
        uint TEMPPERCENT = 0;
        
        ushort TEMPPER = 0;
        
        
        __context__.SourceCodeLine = 271;
        TEMPPERCENT = (uint) ( (GOTOPERCENTDOWN  .UintValue * 100) ) ; 
        __context__.SourceCodeLine = 272;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Mod( TEMPPERCENT , 65535 ) >= 327 ))  ) ) 
            { 
            __context__.SourceCodeLine = 274;
            TEMPPERCENT = (uint) ( ((TEMPPERCENT / 65535) + 1) ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 278;
            TEMPPERCENT = (uint) ( (TEMPPERCENT / 65535) ) ; 
            } 
        
        __context__.SourceCodeLine = 280;
        MakeString ( TEMPSTRING , "{0:d}", (int)TEMPPERCENT) ; 
        __context__.SourceCodeLine = 281;
        TEMPPER = (ushort) ( Functions.Atoi( TEMPSTRING ) ) ; 
        __context__.SourceCodeLine = 282;
        REQUESTEDPOSITION = (uint) ( TEMPPER ) ; 
        __context__.SourceCodeLine = 283;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TEMPPER > 2 ))  ) ) 
            { 
            __context__.SourceCodeLine = 285;
            REQUESTEDPOSITIONMIN = (ushort) ( ((65535 / 100) * (TEMPPER - 2)) ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 289;
            REQUESTEDPOSITIONMIN = (ushort) ( 0 ) ; 
            } 
        
        __context__.SourceCodeLine = 291;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( TEMPPER < 98 ))  ) ) 
            { 
            __context__.SourceCodeLine = 293;
            REQUESTEDPOSITIONMAX = (ushort) ( ((65535 / 100) * (TEMPPER + 2)) ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 297;
            REQUESTEDPOSITIONMAX = (ushort) ( 65535 ) ; 
            } 
        
        __context__.SourceCodeLine = 299;
        POLLCOUNTER = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 300;
        MAXPOLLCOUNT = (ushort) ( 40 ) ; 
        __context__.SourceCodeLine = 301;
        MakeString ( TEMPCOMMAND , "\u00FC\u00F0\u00FF{0}{1}\u00FB{2}\u00FF\u00FF", PARAMCRESTRONADDRESS , GETMOTORADDRESS (  __context__  ) , Functions.Chr (  (int) ( (255 - TEMPPER) ) ) ) ; 
        __context__.SourceCodeLine = 302;
        MakeString ( TOQUEUEMODULE , "{0}{1}\u000D\u000A", TEMPCOMMAND , GETCHECKSUM (  __context__ , TEMPCOMMAND) ) ; 
        __context__.SourceCodeLine = 303;
        POLLPOSITION (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PRESETUP_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString TEMPCOMMAND;
        TEMPCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
        
        
        __context__.SourceCodeLine = 310;
        POLLCOUNTER = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 311;
        MAXPOLLCOUNT = (ushort) ( 40 ) ; 
        __context__.SourceCodeLine = 312;
        MakeString ( TEMPCOMMAND , "\u00FB\u00F0\u00FF{0}{1}\u00FE\u00FF\u00FF\u00FF", PARAMCRESTRONADDRESS , GETMOTORADDRESS (  __context__  ) ) ; 
        __context__.SourceCodeLine = 313;
        MakeString ( TOQUEUEMODULE , "{0}{1}\u000D\u000A", TEMPCOMMAND , GETCHECKSUM (  __context__ , TEMPCOMMAND) ) ; 
        __context__.SourceCodeLine = 314;
        POLLPOSITION (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object PRESETDOWN_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString TEMPCOMMAND;
        TEMPCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
        
        
        __context__.SourceCodeLine = 321;
        POLLCOUNTER = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 322;
        MAXPOLLCOUNT = (ushort) ( 40 ) ; 
        __context__.SourceCodeLine = 323;
        MakeString ( TEMPCOMMAND , "\u00FB\u00F0\u00FF{0}{1}\u00FF\u00FF\u00FF\u00FF", PARAMCRESTRONADDRESS , GETMOTORADDRESS (  __context__  ) ) ; 
        __context__.SourceCodeLine = 324;
        MakeString ( TOQUEUEMODULE , "{0}{1}\u000D\u000A", TEMPCOMMAND , GETCHECKSUM (  __context__ , TEMPCOMMAND) ) ; 
        __context__.SourceCodeLine = 325;
        POLLPOSITION (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object POLL_OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 330;
        POLLCOUNTER = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 331;
        MAXPOLLCOUNT = (ushort) ( 20 ) ; 
        __context__.SourceCodeLine = 332;
        REQUESTEDPOSITION = (uint) ( 65536 ) ; 
        __context__.SourceCodeLine = 333;
        POLLPOSITION (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object GOTOPRESET_OnChange_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString TEMPCOMMAND;
        TEMPCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
        
        ushort TEMPPRESET = 0;
        
        
        __context__.SourceCodeLine = 341;
        TEMPPRESET = (ushort) ( GOTOPRESET  .UshortValue ) ; 
        __context__.SourceCodeLine = 342;
        POLLCOUNTER = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 343;
        MAXPOLLCOUNT = (ushort) ( 40 ) ; 
        __context__.SourceCodeLine = 344;
        MakeString ( TEMPCOMMAND , "\u00FC\u00F0\u00FF{0}{1}\u00FD{2}\u00FF\u00FF", PARAMCRESTRONADDRESS , GETMOTORADDRESS (  __context__  ) , Functions.Chr (  (int) ( (255 - TEMPPRESET) ) ) ) ; 
        __context__.SourceCodeLine = 345;
        MakeString ( TOQUEUEMODULE , "{0}{1}\u000D\u000A", TEMPCOMMAND , GETCHECKSUM (  __context__ , TEMPCOMMAND) ) ; 
        __context__.SourceCodeLine = 346;
        POLLPOSITION (  __context__  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object FROMQUEUEMODULE_OnChange_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString TEMPDATA;
        CrestronString TEMPSEND;
        TEMPDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
        TEMPSEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
        
        
        __context__.SourceCodeLine = 353;
        while ( Functions.TestForTrue  ( ( 1)  ) ) 
            { 
            __context__.SourceCodeLine = 355;
            TEMPSEND  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 356;
            TEMPDATA  .UpdateValue ( Functions.Gather ( "\u000D\u000A" , FROMQUEUEMODULE )  ) ; 
            __context__.SourceCodeLine = 357;
            TEMPSEND  .UpdateValue ( PROCESSDATA (  __context__ , TEMPDATA)  ) ; 
            __context__.SourceCodeLine = 358;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( TEMPSEND ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 360;
                TOQUEUEMODULE  .UpdateValue ( TEMPSEND  ) ; 
                } 
            
            __context__.SourceCodeLine = 362;
            TEMPDATA  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 353;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}


public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 396;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 397;
        POLLCOUNTER = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 398;
        MAXPOLLCOUNT = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 399;
        REQUESTEDPOSITION = (uint) ( 65536 ) ; 
        __context__.SourceCodeLine = 400;
        REQUESTEDPOSITIONMAX = (ushort) ( 65535 ) ; 
        __context__.SourceCodeLine = 401;
        REQUESTEDPOSITIONMIN = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 402;
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    
    THREEBUTTONUP = new Crestron.Logos.SplusObjects.DigitalInput( THREEBUTTONUP__DigitalInput__, this );
    m_DigitalInputList.Add( THREEBUTTONUP__DigitalInput__, THREEBUTTONUP );
    
    THREEBUTTONDOWN = new Crestron.Logos.SplusObjects.DigitalInput( THREEBUTTONDOWN__DigitalInput__, this );
    m_DigitalInputList.Add( THREEBUTTONDOWN__DigitalInput__, THREEBUTTONDOWN );
    
    THREEBUTTONSTOP = new Crestron.Logos.SplusObjects.DigitalInput( THREEBUTTONSTOP__DigitalInput__, this );
    m_DigitalInputList.Add( THREEBUTTONSTOP__DigitalInput__, THREEBUTTONSTOP );
    
    TWOBUTTONUP = new Crestron.Logos.SplusObjects.DigitalInput( TWOBUTTONUP__DigitalInput__, this );
    m_DigitalInputList.Add( TWOBUTTONUP__DigitalInput__, TWOBUTTONUP );
    
    TWOBUTTONDOWN = new Crestron.Logos.SplusObjects.DigitalInput( TWOBUTTONDOWN__DigitalInput__, this );
    m_DigitalInputList.Add( TWOBUTTONDOWN__DigitalInput__, TWOBUTTONDOWN );
    
    PRESETUP = new Crestron.Logos.SplusObjects.DigitalInput( PRESETUP__DigitalInput__, this );
    m_DigitalInputList.Add( PRESETUP__DigitalInput__, PRESETUP );
    
    PRESETDOWN = new Crestron.Logos.SplusObjects.DigitalInput( PRESETDOWN__DigitalInput__, this );
    m_DigitalInputList.Add( PRESETDOWN__DigitalInput__, PRESETDOWN );
    
    POLL = new Crestron.Logos.SplusObjects.DigitalInput( POLL__DigitalInput__, this );
    m_DigitalInputList.Add( POLL__DigitalInput__, POLL );
    
    GOTOPERCENTDOWN = new Crestron.Logos.SplusObjects.AnalogInput( GOTOPERCENTDOWN__AnalogSerialInput__, this );
    m_AnalogInputList.Add( GOTOPERCENTDOWN__AnalogSerialInput__, GOTOPERCENTDOWN );
    
    GOTOPRESET = new Crestron.Logos.SplusObjects.AnalogInput( GOTOPRESET__AnalogSerialInput__, this );
    m_AnalogInputList.Add( GOTOPRESET__AnalogSerialInput__, GOTOPRESET );
    
    CURRENTPOSITION = new Crestron.Logos.SplusObjects.AnalogOutput( CURRENTPOSITION__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CURRENTPOSITION__AnalogSerialOutput__, CURRENTPOSITION );
    
    CURRENTPRESET = new Crestron.Logos.SplusObjects.AnalogOutput( CURRENTPRESET__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CURRENTPRESET__AnalogSerialOutput__, CURRENTPRESET );
    
    CURTAINCONTROLLERPOSITION = new Crestron.Logos.SplusObjects.AnalogOutput( CURTAINCONTROLLERPOSITION__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( CURTAINCONTROLLERPOSITION__AnalogSerialOutput__, CURTAINCONTROLLERPOSITION );
    
    TOQUEUEMODULE = new Crestron.Logos.SplusObjects.StringOutput( TOQUEUEMODULE__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TOQUEUEMODULE__AnalogSerialOutput__, TOQUEUEMODULE );
    
    FROMQUEUEMODULE = new Crestron.Logos.SplusObjects.BufferInput( FROMQUEUEMODULE__AnalogSerialInput__, 500, this );
    m_StringInputList.Add( FROMQUEUEMODULE__AnalogSerialInput__, FROMQUEUEMODULE );
    
    PARAMCRESTRONADDRESS = new StringParameter( PARAMCRESTRONADDRESS__Parameter__, this );
    m_ParameterList.Add( PARAMCRESTRONADDRESS__Parameter__, PARAMCRESTRONADDRESS );
    
    PARAMMOTORADDRESS = new StringParameter( PARAMMOTORADDRESS__Parameter__, this );
    m_ParameterList.Add( PARAMMOTORADDRESS__Parameter__, PARAMMOTORADDRESS );
    
    POLLWAIT_Callback = new WaitFunction( POLLWAIT_CallbackFn );
    
    THREEBUTTONUP.OnDigitalPush.Add( new InputChangeHandlerWrapper( THREEBUTTONUP_OnPush_0, false ) );
    THREEBUTTONDOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( THREEBUTTONDOWN_OnPush_1, false ) );
    THREEBUTTONSTOP.OnDigitalPush.Add( new InputChangeHandlerWrapper( THREEBUTTONSTOP_OnPush_2, false ) );
    TWOBUTTONUP.OnDigitalPush.Add( new InputChangeHandlerWrapper( TWOBUTTONUP_OnPush_3, false ) );
    TWOBUTTONDOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( TWOBUTTONDOWN_OnPush_4, false ) );
    TWOBUTTONUP.OnDigitalRelease.Add( new InputChangeHandlerWrapper( TWOBUTTONUP_OnRelease_5, false ) );
    TWOBUTTONDOWN.OnDigitalRelease.Add( new InputChangeHandlerWrapper( TWOBUTTONUP_OnRelease_5, false ) );
    GOTOPERCENTDOWN.OnAnalogChange.Add( new InputChangeHandlerWrapper( GOTOPERCENTDOWN_OnChange_6, false ) );
    PRESETUP.OnDigitalPush.Add( new InputChangeHandlerWrapper( PRESETUP_OnPush_7, false ) );
    PRESETDOWN.OnDigitalPush.Add( new InputChangeHandlerWrapper( PRESETDOWN_OnPush_8, false ) );
    POLL.OnDigitalPush.Add( new InputChangeHandlerWrapper( POLL_OnPush_9, false ) );
    GOTOPRESET.OnAnalogChange.Add( new InputChangeHandlerWrapper( GOTOPRESET_OnChange_10, false ) );
    FROMQUEUEMODULE.OnSerialChange.Add( new InputChangeHandlerWrapper( FROMQUEUEMODULE_OnChange_11, true ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_SOMFY_SDN2_0_MOTOR_CONTROL_V1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction POLLWAIT_Callback;


const uint THREEBUTTONUP__DigitalInput__ = 0;
const uint THREEBUTTONDOWN__DigitalInput__ = 1;
const uint THREEBUTTONSTOP__DigitalInput__ = 2;
const uint TWOBUTTONUP__DigitalInput__ = 3;
const uint TWOBUTTONDOWN__DigitalInput__ = 4;
const uint PRESETUP__DigitalInput__ = 5;
const uint PRESETDOWN__DigitalInput__ = 6;
const uint POLL__DigitalInput__ = 7;
const uint GOTOPERCENTDOWN__AnalogSerialInput__ = 0;
const uint GOTOPRESET__AnalogSerialInput__ = 1;
const uint FROMQUEUEMODULE__AnalogSerialInput__ = 2;
const uint CURRENTPOSITION__AnalogSerialOutput__ = 0;
const uint CURRENTPRESET__AnalogSerialOutput__ = 1;
const uint CURTAINCONTROLLERPOSITION__AnalogSerialOutput__ = 2;
const uint TOQUEUEMODULE__AnalogSerialOutput__ = 3;
const uint PARAMCRESTRONADDRESS__Parameter__ = 10;
const uint PARAMMOTORADDRESS__Parameter__ = 11;

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


}
