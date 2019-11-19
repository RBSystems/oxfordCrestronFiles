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

namespace UserModule_SOMFY_SDN2_0_QUEUE_V1_0
{
    public class UserModuleClass_SOMFY_SDN2_0_QUEUE_V1_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput INITIALIZE;
        Crestron.Logos.SplusObjects.BufferInput FROMDEVICE;
        Crestron.Logos.SplusObjects.BufferInput FROMMODULES;
        Crestron.Logos.SplusObjects.DigitalOutput INITCOMPLETE;
        Crestron.Logos.SplusObjects.StringOutput TODEVICE;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> TOMODULES;
        ushort NUMBEROFMODULES = 0;
        ushort COMMANDSTOSEND = 0;
        ushort QUERIESTOSEND = 0;
        ushort NEXTCOMMANDSTORE = 0;
        ushort NEXTCOMMANDSEND = 0;
        ushort NEXTQUERYSTORE = 0;
        ushort NEXTQUERYSEND = 0;
        CrestronString [] COMMANDQUEUE;
        CrestronString [] QUERYQUEUE;
        CrestronString [] ADDRESSES;
        private void CALCULATECOMMANDQUEUESIZE (  SplusExecutionContext __context__ ) 
            { 
            ushort A = 0;
            ushort TEMPSIZE = 0;
            
            
            __context__.SourceCodeLine = 70;
            TEMPSIZE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 71;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)500; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 73;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( COMMANDQUEUE[ A ] ) > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 75;
                    TEMPSIZE = (ushort) ( (TEMPSIZE + 1) ) ; 
                    } 
                
                __context__.SourceCodeLine = 71;
                } 
            
            __context__.SourceCodeLine = 78;
            COMMANDSTOSEND = (ushort) ( TEMPSIZE ) ; 
            
            }
            
        private CrestronString GETNEXTCOMMAND (  SplusExecutionContext __context__ ) 
            { 
            CrestronString RETURNSTRING;
            RETURNSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
            
            
            __context__.SourceCodeLine = 85;
            RETURNSTRING  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 86;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( COMMANDSTOSEND > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 88;
                RETURNSTRING  .UpdateValue ( COMMANDQUEUE [ NEXTCOMMANDSEND ]  ) ; 
                __context__.SourceCodeLine = 89;
                COMMANDQUEUE [ NEXTCOMMANDSEND ]  .UpdateValue ( ""  ) ; 
                __context__.SourceCodeLine = 90;
                NEXTCOMMANDSEND = (ushort) ( (NEXTCOMMANDSEND + 1) ) ; 
                __context__.SourceCodeLine = 91;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NEXTCOMMANDSEND > 500 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 93;
                    NEXTCOMMANDSEND = (ushort) ( 1 ) ; 
                    } 
                
                __context__.SourceCodeLine = 95;
                CALCULATECOMMANDQUEUESIZE (  __context__  ) ; 
                } 
            
            __context__.SourceCodeLine = 97;
            return ( RETURNSTRING ) ; 
            
            }
            
        private void ADDCOMMANDTOQUEUE (  SplusExecutionContext __context__, CrestronString PARAMCOMMAND ) 
            { 
            
            __context__.SourceCodeLine = 102;
            COMMANDQUEUE [ NEXTCOMMANDSTORE ]  .UpdateValue ( Functions.Left ( PARAMCOMMAND ,  (int) ( (Functions.Length( PARAMCOMMAND ) - 2) ) )  ) ; 
            __context__.SourceCodeLine = 103;
            NEXTCOMMANDSTORE = (ushort) ( (NEXTCOMMANDSTORE + 1) ) ; 
            __context__.SourceCodeLine = 104;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NEXTCOMMANDSTORE > 500 ))  ) ) 
                { 
                __context__.SourceCodeLine = 106;
                NEXTCOMMANDSTORE = (ushort) ( 1 ) ; 
                } 
            
            __context__.SourceCodeLine = 108;
            CALCULATECOMMANDQUEUESIZE (  __context__  ) ; 
            
            }
            
        private void CALCULATEQUERYQUEUESIZE (  SplusExecutionContext __context__ ) 
            { 
            ushort A = 0;
            ushort TEMPSIZE = 0;
            
            
            __context__.SourceCodeLine = 115;
            TEMPSIZE = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 116;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)500; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 118;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( QUERYQUEUE[ A ] ) > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 120;
                    TEMPSIZE = (ushort) ( (TEMPSIZE + 1) ) ; 
                    } 
                
                __context__.SourceCodeLine = 116;
                } 
            
            __context__.SourceCodeLine = 123;
            QUERIESTOSEND = (ushort) ( TEMPSIZE ) ; 
            
            }
            
        private CrestronString GETNEXTQUERY (  SplusExecutionContext __context__ ) 
            { 
            CrestronString RETURNSTRING;
            RETURNSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
            
            
            __context__.SourceCodeLine = 130;
            RETURNSTRING  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 131;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( QUERIESTOSEND > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 133;
                RETURNSTRING  .UpdateValue ( QUERYQUEUE [ NEXTQUERYSEND ]  ) ; 
                __context__.SourceCodeLine = 134;
                QUERYQUEUE [ NEXTQUERYSEND ]  .UpdateValue ( ""  ) ; 
                __context__.SourceCodeLine = 135;
                NEXTQUERYSEND = (ushort) ( (NEXTQUERYSEND + 1) ) ; 
                __context__.SourceCodeLine = 136;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NEXTQUERYSEND > 500 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 138;
                    NEXTQUERYSEND = (ushort) ( 1 ) ; 
                    } 
                
                __context__.SourceCodeLine = 140;
                CALCULATEQUERYQUEUESIZE (  __context__  ) ; 
                } 
            
            __context__.SourceCodeLine = 142;
            return ( RETURNSTRING ) ; 
            
            }
            
        private void ADDQUERYTOQUEUE (  SplusExecutionContext __context__, CrestronString PARAMCOMMAND ) 
            { 
            
            __context__.SourceCodeLine = 147;
            QUERYQUEUE [ NEXTQUERYSTORE ]  .UpdateValue ( Functions.Left ( PARAMCOMMAND ,  (int) ( (Functions.Length( PARAMCOMMAND ) - 2) ) )  ) ; 
            __context__.SourceCodeLine = 148;
            NEXTQUERYSTORE = (ushort) ( (NEXTQUERYSTORE + 1) ) ; 
            __context__.SourceCodeLine = 149;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NEXTQUERYSTORE > 500 ))  ) ) 
                { 
                __context__.SourceCodeLine = 151;
                NEXTQUERYSTORE = (ushort) ( 1 ) ; 
                } 
            
            __context__.SourceCodeLine = 153;
            CALCULATEQUERYQUEUESIZE (  __context__  ) ; 
            
            }
            
        private void SENDCOMMAND (  SplusExecutionContext __context__ ) 
            { 
            CrestronString TEMPSEND;
            TEMPSEND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
            
            
            __context__.SourceCodeLine = 160;
            TEMPSEND  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 161;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( COMMANDSTOSEND > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 163;
                TEMPSEND  .UpdateValue ( GETNEXTCOMMAND (  __context__  )  ) ; 
                } 
            
            else 
                {
                __context__.SourceCodeLine = 165;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( QUERIESTOSEND > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 167;
                    TEMPSEND  .UpdateValue ( GETNEXTQUERY (  __context__  )  ) ; 
                    } 
                
                }
            
            __context__.SourceCodeLine = 169;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( TEMPSEND ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 171;
                TODEVICE  .UpdateValue ( TEMPSEND  ) ; 
                __context__.SourceCodeLine = 172;
                TEMPSEND  .UpdateValue ( ""  ) ; 
                } 
            
            __context__.SourceCodeLine = 174;
            CreateWait ( "__SPLS_TMPVAR__WAITLABEL_10__" , 20 , __SPLS_TMPVAR__WAITLABEL_10___Callback ) ;
            
            }
            
        public void __SPLS_TMPVAR__WAITLABEL_10___CallbackFn( object stateInfo )
        {
        
            try
            {
                Wait __LocalWait__ = (Wait)stateInfo;
                SplusExecutionContext __context__ = SplusThreadStartCode(__LocalWait__);
                __LocalWait__.RemoveFromList();
                
            
            __context__.SourceCodeLine = 176;
            SENDCOMMAND (  __context__  ) ; 
            
        
        
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler(); }
            
        }
        
    private void PROCESSSOMFYDATA (  SplusExecutionContext __context__, CrestronString PARAMDATA ) 
        { 
        CrestronString TEMPADDRESS;
        TEMPADDRESS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
        
        ushort A = 0;
        
        
        __context__.SourceCodeLine = 185;
        TEMPADDRESS  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 186;
        TEMPADDRESS  .UpdateValue ( Functions.Mid ( PARAMDATA ,  (int) ( 4 ) ,  (int) ( 3 ) )  ) ; 
        __context__.SourceCodeLine = 187;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( TEMPADDRESS ) > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 189;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)NUMBEROFMODULES; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 191;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TEMPADDRESS == ADDRESSES[ A ]))  ) ) 
                    { 
                    __context__.SourceCodeLine = 193;
                    TOMODULES [ A]  .UpdateValue ( PARAMDATA + "\u000D\u000A"  ) ; 
                    __context__.SourceCodeLine = 194;
                    break ; 
                    } 
                
                __context__.SourceCodeLine = 189;
                } 
            
            } 
        
        
        }
        
    private void CHECKINITSTATUS (  SplusExecutionContext __context__ ) 
        { 
        ushort A = 0;
        ushort EMPTYFOUND = 0;
        
        
        __context__.SourceCodeLine = 204;
        EMPTYFOUND = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 205;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)NUMBEROFMODULES; 
        int __FN_FORSTEP_VAL__1 = (int)1; 
        for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 207;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( ADDRESSES[ A ] ) == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 209;
                EMPTYFOUND = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 210;
                break ; 
                } 
            
            __context__.SourceCodeLine = 205;
            } 
        
        __context__.SourceCodeLine = 213;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EMPTYFOUND == 0))  ) ) 
            { 
            __context__.SourceCodeLine = 215;
            INITCOMPLETE  .Value = (ushort) ( 1 ) ; 
            __context__.SourceCodeLine = 216;
            SENDCOMMAND (  __context__  ) ; 
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 220;
            INITCOMPLETE  .Value = (ushort) ( 0 ) ; 
            } 
        
        
        }
        
    private void ADDADDRESS (  SplusExecutionContext __context__, ushort PARAMADDRESSNUM , CrestronString PARAMDATA ) 
        { 
        
        __context__.SourceCodeLine = 226;
        ADDRESSES [ PARAMADDRESSNUM ]  .UpdateValue ( PARAMDATA  ) ; 
        __context__.SourceCodeLine = 227;
        CHECKINITSTATUS (  __context__  ) ; 
        
        }
        
    private void PROCESSMODULEDATA (  SplusExecutionContext __context__, CrestronString PARAMDATA ) 
        { 
        CrestronString TEMPSTARTBYTES;
        CrestronString TEMPADDRESS;
        TEMPSTARTBYTES  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
        TEMPADDRESS  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
        
        ushort TEMPNUMBER = 0;
        
        
        __context__.SourceCodeLine = 234;
        TEMPSTARTBYTES  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 235;
        TEMPADDRESS  .UpdateValue ( ""  ) ; 
        __context__.SourceCodeLine = 236;
        TEMPNUMBER = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 238;
        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "Send Name" , PARAMDATA ) > 0 ))  ) ) 
            { 
            __context__.SourceCodeLine = 240;
            TEMPNUMBER = (ushort) ( Functions.Atoi( PARAMDATA ) ) ; 
            __context__.SourceCodeLine = 241;
            TEMPADDRESS  .UpdateValue ( Functions.Mid ( PARAMDATA ,  (int) ( (Functions.Find( "= " , PARAMDATA ) + 2) ) ,  (int) ( 3 ) )  ) ; 
            __context__.SourceCodeLine = 242;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( TEMPNUMBER > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Functions.Length( TEMPADDRESS ) > 0 ) )) ))  ) ) 
                { 
                __context__.SourceCodeLine = 244;
                ADDADDRESS (  __context__ , (ushort)( TEMPNUMBER ), TEMPADDRESS) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 248;
                GenerateUserNotice ( "Somfy ILT3: Send Name error: {0}", PARAMDATA ) ; 
                } 
            
            } 
        
        else 
            { 
            __context__.SourceCodeLine = 253;
            TEMPSTARTBYTES  .UpdateValue ( Functions.Left ( PARAMDATA ,  (int) ( 3 ) )  ) ; 
            __context__.SourceCodeLine = 254;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (TEMPSTARTBYTES == "\u00F3\u00F4\u00FF"))  ) ) 
                { 
                __context__.SourceCodeLine = 256;
                ADDQUERYTOQUEUE (  __context__ , PARAMDATA) ; 
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 260;
                ADDCOMMANDTOQUEUE (  __context__ , PARAMDATA) ; 
                } 
            
            } 
        
        
        }
        
    object INITIALIZE_OnPush_0 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            ushort A = 0;
            
            
            __context__.SourceCodeLine = 272;
            Functions.SetArray ( ADDRESSES , "" ) ; 
            __context__.SourceCodeLine = 273;
            CHECKINITSTATUS (  __context__  ) ; 
            __context__.SourceCodeLine = 274;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)NUMBEROFMODULES; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( A  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (A  >= __FN_FORSTART_VAL__1) && (A  <= __FN_FOREND_VAL__1) ) : ( (A  <= __FN_FORSTART_VAL__1) && (A  >= __FN_FOREND_VAL__1) ) ; A  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 276;
                MakeString ( TOMODULES [ A] , "Send Name {0:d}\u000D\u000A", (short)A) ; 
                __context__.SourceCodeLine = 274;
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object FROMDEVICE_OnChange_1 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString TEMPDATA;
        TEMPDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
        
        
        __context__.SourceCodeLine = 284;
        while ( Functions.TestForTrue  ( ( 1)  ) ) 
            { 
            __context__.SourceCodeLine = 286;
            try 
                { 
                __context__.SourceCodeLine = 288;
                TEMPDATA  .UpdateValue ( Functions.Gather ( 16, FROMDEVICE )  ) ; 
                __context__.SourceCodeLine = 289;
                PROCESSSOMFYDATA (  __context__ , TEMPDATA) ; 
                __context__.SourceCodeLine = 290;
                TEMPDATA  .UpdateValue ( ""  ) ; 
                } 
            
            catch (Exception __splus_exception__)
                { 
                SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
                
                __context__.SourceCodeLine = 294;
                GenerateUserNotice ( "Somfy ILT3: fromDevice: Error: {0}", Functions.GetExceptionMessage (  __splus_exceptionobj__ ) ) ; 
                
                }
                
                __context__.SourceCodeLine = 284;
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object FROMMODULES_OnChange_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        CrestronString TEMPDATA;
        TEMPDATA  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
        
        
        __context__.SourceCodeLine = 303;
        while ( Functions.TestForTrue  ( ( 1)  ) ) 
            { 
            __context__.SourceCodeLine = 305;
            try 
                { 
                __context__.SourceCodeLine = 307;
                TEMPDATA  .UpdateValue ( Functions.Gather ( "\u000D\u000A" , FROMMODULES )  ) ; 
                __context__.SourceCodeLine = 308;
                PROCESSMODULEDATA (  __context__ , TEMPDATA) ; 
                __context__.SourceCodeLine = 309;
                TEMPDATA  .UpdateValue ( ""  ) ; 
                } 
            
            catch (Exception __splus_exception__)
                { 
                SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
                
                __context__.SourceCodeLine = 313;
                GenerateUserNotice ( "Somfy ILT3: fromDevice: Error: {0}", Functions.GetExceptionMessage (  __splus_exceptionobj__ ) ) ; 
                
                }
                
                __context__.SourceCodeLine = 303;
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
        
        __context__.SourceCodeLine = 360;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 361;
        NUMBEROFMODULES = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 362;
        COMMANDSTOSEND = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 363;
        QUERIESTOSEND = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 364;
        NEXTCOMMANDSTORE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 365;
        NEXTCOMMANDSEND = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 366;
        NEXTQUERYSTORE = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 367;
        NEXTQUERYSEND = (ushort) ( 1 ) ; 
        __context__.SourceCodeLine = 368;
        
        __context__.SourceCodeLine = 372;
        Functions.SetArray ( ADDRESSES , "" ) ; 
        __context__.SourceCodeLine = 373;
        ushort __FN_FORSTART_VAL__1 = (ushort) ( 100 ) ;
        ushort __FN_FOREND_VAL__1 = (ushort)1; 
        int __FN_FORSTEP_VAL__1 = (int)Functions.ToLongInteger( -( 1 ) ); 
        for ( NUMBEROFMODULES  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (NUMBEROFMODULES  >= __FN_FORSTART_VAL__1) && (NUMBEROFMODULES  <= __FN_FOREND_VAL__1) ) : ( (NUMBEROFMODULES  <= __FN_FORSTART_VAL__1) && (NUMBEROFMODULES  >= __FN_FOREND_VAL__1) ) ; NUMBEROFMODULES  += (ushort)__FN_FORSTEP_VAL__1) 
            { 
            __context__.SourceCodeLine = 375;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IsSignalDefined( TOMODULES[ NUMBEROFMODULES ] ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 377;
                break ; 
                } 
            
            __context__.SourceCodeLine = 373;
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    COMMANDQUEUE  = new CrestronString[ 501 ];
    for( uint i = 0; i < 501; i++ )
        COMMANDQUEUE [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
    QUERYQUEUE  = new CrestronString[ 501 ];
    for( uint i = 0; i < 501; i++ )
        QUERYQUEUE [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 25, this );
    ADDRESSES  = new CrestronString[ 101 ];
    for( uint i = 0; i < 101; i++ )
        ADDRESSES [i] = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
    
    INITIALIZE = new Crestron.Logos.SplusObjects.DigitalInput( INITIALIZE__DigitalInput__, this );
    m_DigitalInputList.Add( INITIALIZE__DigitalInput__, INITIALIZE );
    
    INITCOMPLETE = new Crestron.Logos.SplusObjects.DigitalOutput( INITCOMPLETE__DigitalOutput__, this );
    m_DigitalOutputList.Add( INITCOMPLETE__DigitalOutput__, INITCOMPLETE );
    
    TODEVICE = new Crestron.Logos.SplusObjects.StringOutput( TODEVICE__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TODEVICE__AnalogSerialOutput__, TODEVICE );
    
    TOMODULES = new InOutArray<StringOutput>( 100, this );
    for( uint i = 0; i < 100; i++ )
    {
        TOMODULES[i+1] = new Crestron.Logos.SplusObjects.StringOutput( TOMODULES__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( TOMODULES__AnalogSerialOutput__ + i, TOMODULES[i+1] );
    }
    
    FROMDEVICE = new Crestron.Logos.SplusObjects.BufferInput( FROMDEVICE__AnalogSerialInput__, 500, this );
    m_StringInputList.Add( FROMDEVICE__AnalogSerialInput__, FROMDEVICE );
    
    FROMMODULES = new Crestron.Logos.SplusObjects.BufferInput( FROMMODULES__AnalogSerialInput__, 5000, this );
    m_StringInputList.Add( FROMMODULES__AnalogSerialInput__, FROMMODULES );
    
    __SPLS_TMPVAR__WAITLABEL_10___Callback = new WaitFunction( __SPLS_TMPVAR__WAITLABEL_10___CallbackFn );
    
    INITIALIZE.OnDigitalPush.Add( new InputChangeHandlerWrapper( INITIALIZE_OnPush_0, false ) );
    FROMDEVICE.OnSerialChange.Add( new InputChangeHandlerWrapper( FROMDEVICE_OnChange_1, true ) );
    FROMMODULES.OnSerialChange.Add( new InputChangeHandlerWrapper( FROMMODULES_OnChange_2, true ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public UserModuleClass_SOMFY_SDN2_0_QUEUE_V1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}


private WaitFunction __SPLS_TMPVAR__WAITLABEL_10___Callback;


const uint INITIALIZE__DigitalInput__ = 0;
const uint FROMDEVICE__AnalogSerialInput__ = 0;
const uint FROMMODULES__AnalogSerialInput__ = 1;
const uint INITCOMPLETE__DigitalOutput__ = 0;
const uint TODEVICE__AnalogSerialOutput__ = 0;
const uint TOMODULES__AnalogSerialOutput__ = 1;

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
