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

namespace CrestronModule_ZUM_AV_BRIDGE_MODULE__EXPANDED__V1_1_0
{
    public class CrestronModuleClass_ZUM_AV_BRIDGE_MODULE__EXPANDED__V1_1_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        Crestron.Logos.SplusObjects.DigitalInput ROOM_RECALL_SCENE_1;
        Crestron.Logos.SplusObjects.DigitalInput ROOM_RECALL_SCENE_2;
        Crestron.Logos.SplusObjects.DigitalInput ROOM_RECALL_SCENE_3;
        Crestron.Logos.SplusObjects.DigitalInput ROOM_RECALL_SCENE_4;
        Crestron.Logos.SplusObjects.DigitalInput ROOM_RECALL_SCENE_5;
        Crestron.Logos.SplusObjects.DigitalInput ROOM_RECALL_SCENE_6;
        Crestron.Logos.SplusObjects.DigitalInput ROOM_RECALL_SCENE_7;
        Crestron.Logos.SplusObjects.DigitalInput ROOM_RECALL_SCENE_8;
        Crestron.Logos.SplusObjects.DigitalInput ROOM_RECALL_SCENE_16;
        Crestron.Logos.SplusObjects.DigitalInput ROOM_RECALL_OFF;
        Crestron.Logos.SplusObjects.DigitalInput ROOM_SAVE_SCENE_1;
        Crestron.Logos.SplusObjects.DigitalInput ROOM_SAVE_SCENE_2;
        Crestron.Logos.SplusObjects.DigitalInput ROOM_SAVE_SCENE_3;
        Crestron.Logos.SplusObjects.DigitalInput ROOM_SAVE_SCENE_4;
        Crestron.Logos.SplusObjects.DigitalInput ROOM_SAVE_SCENE_5;
        Crestron.Logos.SplusObjects.DigitalInput ROOM_SAVE_SCENE_6;
        Crestron.Logos.SplusObjects.DigitalInput ROOM_SAVE_SCENE_7;
        Crestron.Logos.SplusObjects.DigitalInput ROOM_SAVE_SCENE_8;
        Crestron.Logos.SplusObjects.DigitalInput ROOM_SAVE_SCENE_16;
        Crestron.Logos.SplusObjects.DigitalOutput ROOM_IS_ON_FB;
        Crestron.Logos.SplusObjects.DigitalOutput ROOM_SCENE_1_FB;
        Crestron.Logos.SplusObjects.DigitalOutput ROOM_SCENE_2_FB;
        Crestron.Logos.SplusObjects.DigitalOutput ROOM_SCENE_3_FB;
        Crestron.Logos.SplusObjects.DigitalOutput ROOM_SCENE_4_FB;
        Crestron.Logos.SplusObjects.DigitalOutput ROOM_SCENE_5_FB;
        Crestron.Logos.SplusObjects.DigitalOutput ROOM_SCENE_6_FB;
        Crestron.Logos.SplusObjects.DigitalOutput ROOM_SCENE_7_FB;
        Crestron.Logos.SplusObjects.DigitalOutput ROOM_SCENE_8_FB;
        Crestron.Logos.SplusObjects.DigitalOutput ROOM_SCENE_16_FB;
        Crestron.Logos.SplusObjects.DigitalOutput ROOM_SCENE_OFF_FB;
        Crestron.Logos.SplusObjects.DigitalOutput ROOM_IS_OCCUPIED_FB;
        Crestron.Logos.SplusObjects.DigitalOutput ROOM_DAYLIGHTING_ENABLED_FB;
        Crestron.Logos.SplusObjects.DigitalInput ENABLE_LEVEL_FB;
        Crestron.Logos.SplusObjects.DigitalInput DISABLE_LEVEL_FB;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> KP_01_BUTTON_TAP;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> KP_01_BUTTON_HOLD;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> KP_02_BUTTON_TAP;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> KP_02_BUTTON_HOLD;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> KP_03_BUTTON_TAP;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> KP_03_BUTTON_HOLD;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> KP_04_BUTTON_TAP;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> KP_04_BUTTON_HOLD;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> KP_05_BUTTON_TAP;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> KP_05_BUTTON_HOLD;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> KP_06_BUTTON_TAP;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> KP_06_BUTTON_HOLD;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> KP_07_BUTTON_TAP;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> KP_07_BUTTON_HOLD;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> KP_08_BUTTON_TAP;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> KP_08_BUTTON_HOLD;
        Crestron.Logos.SplusObjects.BufferInput FROMAVBRIDGE;
        Crestron.Logos.SplusObjects.AnalogInput ROOM_LEVEL;
        InOutArray<Crestron.Logos.SplusObjects.AnalogInput> DIRECT_LEVEL_L;
        Crestron.Logos.SplusObjects.StringOutput TOAVBRIDGE;
        InOutArray<Crestron.Logos.SplusObjects.AnalogOutput> LOAD_LEVEL_FB_L;
        ushort TAPTIME = 0;
        ushort ENABLE_REPORTING = 0;
        ushort DEBUGMODE = 0;
        ushort DEBUGLEVEL = 0;
        CrestronString TAP__DOLLAR__;
        CrestronString HOLD__DOLLAR__;
        CrestronString RELEASE__DOLLAR__;
        CrestronString BUTTON__DOLLAR__;
        CrestronString ROOM__DOLLAR__;
        CrestronString SCENE__DOLLAR__;
        CrestronString DL_ACTION__DOLLAR__;
        CrestronString OCC_ACTION__DOLLAR__;
        CrestronString LIGHTSON__DOLLAR__;
        CrestronString OCCUPANCY__DOLLAR__;
        CrestronString ROOM_LIGHTS__DOLLAR__;
        CrestronString LIGHTSOFF__DOLLAR__;
        CrestronString LEVEL__DOLLAR__;
        CrestronString SYNC__DOLLAR__;
        private void TAP_KP_1 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 284;
            Functions.Pulse ( TAPTIME, KP_01_BUTTON_TAP [ X] ) ; 
            
            }
            
        private void TAP_KP_2 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 288;
            Functions.Pulse ( TAPTIME, KP_02_BUTTON_TAP [ X] ) ; 
            
            }
            
        private void TAP_KP_3 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 292;
            Functions.Pulse ( TAPTIME, KP_03_BUTTON_TAP [ X] ) ; 
            
            }
            
        private void TAP_KP_4 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 296;
            Functions.Pulse ( TAPTIME, KP_04_BUTTON_TAP [ X] ) ; 
            
            }
            
        private void TAP_KP_5 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 300;
            Functions.Pulse ( TAPTIME, KP_05_BUTTON_TAP [ X] ) ; 
            
            }
            
        private void TAP_KP_6 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 304;
            Functions.Pulse ( TAPTIME, KP_06_BUTTON_TAP [ X] ) ; 
            
            }
            
        private void TAP_KP_7 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 308;
            Functions.Pulse ( TAPTIME, KP_07_BUTTON_TAP [ X] ) ; 
            
            }
            
        private void TAP_KP_8 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 312;
            Functions.Pulse ( TAPTIME, KP_08_BUTTON_TAP [ X] ) ; 
            
            }
            
        private void HOLD_KP_1 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 318;
            KP_01_BUTTON_HOLD [ X]  .Value = (ushort) ( 1 ) ; 
            
            }
            
        private void HOLD_KP_2 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 322;
            KP_02_BUTTON_HOLD [ X]  .Value = (ushort) ( 1 ) ; 
            
            }
            
        private void HOLD_KP_3 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 326;
            KP_03_BUTTON_HOLD [ X]  .Value = (ushort) ( 1 ) ; 
            
            }
            
        private void HOLD_KP_4 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 330;
            KP_04_BUTTON_HOLD [ X]  .Value = (ushort) ( 1 ) ; 
            
            }
            
        private void HOLD_KP_5 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 334;
            KP_05_BUTTON_HOLD [ X]  .Value = (ushort) ( 1 ) ; 
            
            }
            
        private void HOLD_KP_6 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 338;
            KP_06_BUTTON_HOLD [ X]  .Value = (ushort) ( 1 ) ; 
            
            }
            
        private void HOLD_KP_7 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 342;
            KP_07_BUTTON_HOLD [ X]  .Value = (ushort) ( 1 ) ; 
            
            }
            
        private void HOLD_KP_8 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 346;
            KP_08_BUTTON_HOLD [ X]  .Value = (ushort) ( 1 ) ; 
            
            }
            
        private void RELEASE_KP_1 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 355;
            KP_01_BUTTON_HOLD [ X]  .Value = (ushort) ( 0 ) ; 
            
            }
            
        private void RELEASE_KP_2 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 359;
            KP_02_BUTTON_HOLD [ X]  .Value = (ushort) ( 0 ) ; 
            
            }
            
        private void RELEASE_KP_3 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 363;
            KP_03_BUTTON_HOLD [ X]  .Value = (ushort) ( 0 ) ; 
            
            }
            
        private void RELEASE_KP_4 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 367;
            KP_04_BUTTON_HOLD [ X]  .Value = (ushort) ( 0 ) ; 
            
            }
            
        private void RELEASE_KP_5 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 371;
            KP_05_BUTTON_HOLD [ X]  .Value = (ushort) ( 0 ) ; 
            
            }
            
        private void RELEASE_KP_6 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 375;
            KP_06_BUTTON_HOLD [ X]  .Value = (ushort) ( 0 ) ; 
            
            }
            
        private void RELEASE_KP_7 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 379;
            KP_07_BUTTON_HOLD [ X]  .Value = (ushort) ( 0 ) ; 
            
            }
            
        private void RELEASE_KP_8 (  SplusExecutionContext __context__, ushort X ) 
            { 
            
            __context__.SourceCodeLine = 383;
            KP_08_BUTTON_HOLD [ X]  .Value = (ushort) ( 0 ) ; 
            
            }
            
        private void PROCESS_MSG (  SplusExecutionContext __context__, CrestronString PAYLOAD__DOLLAR__ ) 
            { 
            ushort X = 0;
            ushort Y = 0;
            ushort BUTTONNUM = 0;
            ushort KPID = 0;
            
            CrestronString EXTRACT__DOLLAR__;
            CrestronString LID__DOLLAR__;
            EXTRACT__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
            LID__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 3, this );
            
            
            __context__.SourceCodeLine = 393;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Find( "!" , PAYLOAD__DOLLAR__ ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 395;
                Print( "! found -  {0}\r\n", PAYLOAD__DOLLAR__ ) ; 
                __context__.SourceCodeLine = 396;
                return ; 
                } 
            
            __context__.SourceCodeLine = 399;
            if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                {
                __context__.SourceCodeLine = 399;
                Print( "Initializing Process_msg: Payload = {0}\r\n", PAYLOAD__DOLLAR__ ) ; 
                }
            
            __context__.SourceCodeLine = 402;
            if ( Functions.TestForTrue  ( ( Functions.Find( TAP__DOLLAR__ , PAYLOAD__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 404;
                X = (ushort) ( Functions.Find( TAP__DOLLAR__ , PAYLOAD__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 405;
                EXTRACT__DOLLAR__  .UpdateValue ( Functions.Mid ( PAYLOAD__DOLLAR__ ,  (int) ( (X + 4) ) ,  (int) ( 1 ) )  ) ; 
                __context__.SourceCodeLine = 406;
                BUTTONNUM = (ushort) ( Functions.Atoi( EXTRACT__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 407;
                KPID = (ushort) ( Functions.Atoi( Functions.Mid( PAYLOAD__DOLLAR__ , (int)( (Functions.Find( "K" , PAYLOAD__DOLLAR__ ) + 1) ) , (int)( 2 ) ) ) ) ; 
                __context__.SourceCodeLine = 408;
                if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 412;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( DEBUGLEVEL > 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 414;
                        Print( "Taps find, payload = {0}, POS = {1:d}, Extracted = {2} - num {3:d}\r\n  KPID = {4:d}", PAYLOAD__DOLLAR__ , (short)X, EXTRACT__DOLLAR__ , (short)BUTTONNUM, (short)KPID) ; 
                        __context__.SourceCodeLine = 419;
                        Print( "Keypad id = {0:d}, Button Tapped = {1:d} ", (short)KPID, (short)BUTTONNUM) ; 
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 423;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_1__ = ((int)KPID);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 427;
                            TAP_KP_1 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 431;
                            TAP_KP_2 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 435;
                            TAP_KP_3 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 439;
                            TAP_KP_4 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 5) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 443;
                            TAP_KP_5 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 6) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 447;
                            TAP_KP_6 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 7) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 451;
                            TAP_KP_7 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 8) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 455;
                            TAP_KP_8 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        } 
                        
                    }
                    
                
                } 
            
            __context__.SourceCodeLine = 462;
            if ( Functions.TestForTrue  ( ( Functions.Find( HOLD__DOLLAR__ , PAYLOAD__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 464;
                X = (ushort) ( Functions.Find( HOLD__DOLLAR__ , PAYLOAD__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 465;
                EXTRACT__DOLLAR__  .UpdateValue ( Functions.Mid ( PAYLOAD__DOLLAR__ ,  (int) ( (X + 5) ) ,  (int) ( 1 ) )  ) ; 
                __context__.SourceCodeLine = 466;
                BUTTONNUM = (ushort) ( Functions.Atoi( EXTRACT__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 467;
                KPID = (ushort) ( Functions.Atoi( Functions.Mid( PAYLOAD__DOLLAR__ , (int)( (Functions.Find( "K" , PAYLOAD__DOLLAR__ ) + 1) ) , (int)( 2 ) ) ) ) ; 
                __context__.SourceCodeLine = 468;
                if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 470;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( DEBUGLEVEL > 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 472;
                        Print( "HOLD find, payload = {0}, POS = {1:d}, Extracted = {2} - num {3:d}\r\n  KPID = {4:d}", PAYLOAD__DOLLAR__ , (short)X, EXTRACT__DOLLAR__ , (short)BUTTONNUM, (short)KPID) ; 
                        __context__.SourceCodeLine = 477;
                        Print( "Keypad id = {0:d}, Button held = {1:d} ", (short)KPID, (short)BUTTONNUM) ; 
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 481;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_2__ = ((int)KPID);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 1) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 485;
                            HOLD_KP_1 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 2) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 489;
                            HOLD_KP_2 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 3) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 493;
                            HOLD_KP_3 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 4) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 497;
                            HOLD_KP_4 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 5) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 501;
                            HOLD_KP_5 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 6) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 505;
                            HOLD_KP_6 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 7) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 509;
                            HOLD_KP_7 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_2__ == ( 8) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 513;
                            HOLD_KP_8 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        } 
                        
                    }
                    
                
                } 
            
            __context__.SourceCodeLine = 519;
            if ( Functions.TestForTrue  ( ( Functions.Find( RELEASE__DOLLAR__ , PAYLOAD__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 521;
                X = (ushort) ( Functions.Find( RELEASE__DOLLAR__ , PAYLOAD__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 522;
                EXTRACT__DOLLAR__  .UpdateValue ( Functions.Mid ( PAYLOAD__DOLLAR__ ,  (int) ( (X + 8) ) ,  (int) ( 1 ) )  ) ; 
                __context__.SourceCodeLine = 523;
                BUTTONNUM = (ushort) ( Functions.Atoi( EXTRACT__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 524;
                KPID = (ushort) ( Functions.Atoi( Functions.Mid( PAYLOAD__DOLLAR__ , (int)( (Functions.Find( "K" , PAYLOAD__DOLLAR__ ) + 1) ) , (int)( 2 ) ) ) ) ; 
                __context__.SourceCodeLine = 525;
                if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 527;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( DEBUGLEVEL > 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 529;
                        Print( "release find, payload = {0}, POS = {1:d}, Extracted = {2} - num {3:d}\r\n  KPID = {4:d}\r\n", PAYLOAD__DOLLAR__ , (short)X, EXTRACT__DOLLAR__ , (short)BUTTONNUM, (short)KPID) ; 
                        __context__.SourceCodeLine = 534;
                        Print( "Keypad id = {0:d}, Button held = {1:d} \r\n", (short)KPID, (short)BUTTONNUM) ; 
                        } 
                    
                    } 
                
                __context__.SourceCodeLine = 539;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_3__ = ((int)KPID);
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 1) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 543;
                            RELEASE_KP_1 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 2) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 547;
                            RELEASE_KP_2 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 3) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 551;
                            RELEASE_KP_3 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 4) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 555;
                            RELEASE_KP_4 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 5) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 559;
                            RELEASE_KP_5 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 6) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 563;
                            RELEASE_KP_6 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 7) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 567;
                            RELEASE_KP_7 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_3__ == ( 8) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 571;
                            RELEASE_KP_8 (  __context__ , (ushort)( BUTTONNUM )) ; 
                            } 
                        
                        } 
                        
                    }
                    
                
                } 
            
            __context__.SourceCodeLine = 581;
            if ( Functions.TestForTrue  ( ( Functions.Find( DL_ACTION__DOLLAR__ , PAYLOAD__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 583;
                X = (ushort) ( Functions.Find( DL_ACTION__DOLLAR__ , PAYLOAD__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 584;
                EXTRACT__DOLLAR__  .UpdateValue ( Functions.Mid ( PAYLOAD__DOLLAR__ ,  (int) ( (X + 16) ) ,  (int) ( 4 ) )  ) ; 
                __context__.SourceCodeLine = 585;
                if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 587;
                    Print( "Daylighting Actions Processing: , payload = {0}, POS = {1:d}, Extracted = {2} \r\n", PAYLOAD__DOLLAR__ , (short)X, EXTRACT__DOLLAR__ ) ; 
                    } 
                
                __context__.SourceCodeLine = 591;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EXTRACT__DOLLAR__ == "enab"))  ) ) 
                    { 
                    __context__.SourceCodeLine = 593;
                    if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                        { 
                        __context__.SourceCodeLine = 595;
                        Print( "DL Enabled\r\n") ; 
                        } 
                    
                    __context__.SourceCodeLine = 597;
                    ROOM_DAYLIGHTING_ENABLED_FB  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 599;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EXTRACT__DOLLAR__ == "disa"))  ) ) 
                        { 
                        __context__.SourceCodeLine = 601;
                        if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                            { 
                            __context__.SourceCodeLine = 603;
                            Print( "DL Disabled\r\n") ; 
                            } 
                        
                        __context__.SourceCodeLine = 605;
                        ROOM_DAYLIGHTING_ENABLED_FB  .Value = (ushort) ( 0 ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 609;
                        if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                            { 
                            __context__.SourceCodeLine = 612;
                            Print( "Daylighting - Unknown command - {0}\r\n", EXTRACT__DOLLAR__ ) ; 
                            } 
                        
                        } 
                    
                    }
                
                } 
            
            __context__.SourceCodeLine = 621;
            if ( Functions.TestForTrue  ( ( Functions.Find( OCCUPANCY__DOLLAR__ , PAYLOAD__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 623;
                X = (ushort) ( Functions.Find( OCCUPANCY__DOLLAR__ , PAYLOAD__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 624;
                EXTRACT__DOLLAR__  .UpdateValue ( Functions.Mid ( PAYLOAD__DOLLAR__ ,  (int) ( (X + 10) ) ,  (int) ( 3 ) )  ) ; 
                __context__.SourceCodeLine = 625;
                if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 627;
                    Print( "Occupancy State Processing:\r\n payload = {0}, POS = {1:d}, Extracted = {2} \r\n", PAYLOAD__DOLLAR__ , (short)X, EXTRACT__DOLLAR__ ) ; 
                    } 
                
                __context__.SourceCodeLine = 631;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EXTRACT__DOLLAR__ == "occ"))  ) ) 
                    { 
                    __context__.SourceCodeLine = 633;
                    if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                        { 
                        __context__.SourceCodeLine = 635;
                        Print( "Room Occupied\r\n") ; 
                        } 
                    
                    __context__.SourceCodeLine = 637;
                    ROOM_IS_OCCUPIED_FB  .Value = (ushort) ( 1 ) ; 
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 639;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EXTRACT__DOLLAR__ == "vac"))  ) ) 
                        { 
                        __context__.SourceCodeLine = 641;
                        if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                            { 
                            __context__.SourceCodeLine = 643;
                            Print( "Room Vacant\r\n") ; 
                            } 
                        
                        __context__.SourceCodeLine = 645;
                        ROOM_IS_OCCUPIED_FB  .Value = (ushort) ( 0 ) ; 
                        } 
                    
                    else 
                        { 
                        __context__.SourceCodeLine = 649;
                        if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                            { 
                            __context__.SourceCodeLine = 651;
                            Print( "Occupancy Action - Unknown command - {0}\r\n", EXTRACT__DOLLAR__ ) ; 
                            } 
                        
                        } 
                    
                    }
                
                } 
            
            __context__.SourceCodeLine = 659;
            if ( Functions.TestForTrue  ( ( Functions.Find( SCENE__DOLLAR__ , PAYLOAD__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 661;
                X = (ushort) ( Functions.Find( SCENE__DOLLAR__ , PAYLOAD__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 662;
                EXTRACT__DOLLAR__  .UpdateValue ( Functions.Mid ( PAYLOAD__DOLLAR__ ,  (int) ( (X + 6) ) ,  (int) ( 2 ) )  ) ; 
                __context__.SourceCodeLine = 663;
                if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 665;
                    Print( "Scene Reporting:\r\n payload = {0}, POS = {1:d}, Extracted = {2} \r\n", PAYLOAD__DOLLAR__ , (short)X, EXTRACT__DOLLAR__ ) ; 
                    } 
                
                __context__.SourceCodeLine = 669;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_4__ = ((int)Functions.Atoi( EXTRACT__DOLLAR__ ));
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 0) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 673;
                            if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 675;
                                Print( "Scene 0, String Value {0}\r\n", EXTRACT__DOLLAR__ ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 677;
                            ROOM_SCENE_1_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 678;
                            ROOM_SCENE_2_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 679;
                            ROOM_SCENE_3_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 680;
                            ROOM_SCENE_4_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 681;
                            ROOM_SCENE_5_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 682;
                            ROOM_SCENE_6_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 683;
                            ROOM_SCENE_7_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 684;
                            ROOM_SCENE_8_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 685;
                            ROOM_SCENE_16_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 686;
                            ROOM_SCENE_OFF_FB  .Value = (ushort) ( 1 ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 1) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 692;
                            if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 694;
                                Print( "Scene 1, String Value {0}\r\n", EXTRACT__DOLLAR__ ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 696;
                            ROOM_SCENE_1_FB  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 697;
                            ROOM_SCENE_2_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 698;
                            ROOM_SCENE_3_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 699;
                            ROOM_SCENE_4_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 700;
                            ROOM_SCENE_5_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 701;
                            ROOM_SCENE_6_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 702;
                            ROOM_SCENE_7_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 703;
                            ROOM_SCENE_8_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 704;
                            ROOM_SCENE_16_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 705;
                            ROOM_SCENE_OFF_FB  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 2) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 709;
                            if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 711;
                                Print( "Scene 2, String Value {0}\r\n", EXTRACT__DOLLAR__ ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 713;
                            ROOM_SCENE_1_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 714;
                            ROOM_SCENE_2_FB  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 715;
                            ROOM_SCENE_3_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 716;
                            ROOM_SCENE_4_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 717;
                            ROOM_SCENE_5_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 718;
                            ROOM_SCENE_6_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 719;
                            ROOM_SCENE_7_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 720;
                            ROOM_SCENE_8_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 721;
                            ROOM_SCENE_16_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 722;
                            ROOM_SCENE_OFF_FB  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 3) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 727;
                            if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 729;
                                Print( "Scene 3, String Value {0}\r\n", EXTRACT__DOLLAR__ ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 731;
                            ROOM_SCENE_1_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 732;
                            ROOM_SCENE_2_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 733;
                            ROOM_SCENE_3_FB  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 734;
                            ROOM_SCENE_4_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 735;
                            ROOM_SCENE_5_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 736;
                            ROOM_SCENE_6_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 737;
                            ROOM_SCENE_7_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 738;
                            ROOM_SCENE_8_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 739;
                            ROOM_SCENE_16_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 740;
                            ROOM_SCENE_OFF_FB  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 4) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 745;
                            if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 747;
                                Print( "Scene 4, String Value {0}\r\n", EXTRACT__DOLLAR__ ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 749;
                            ROOM_SCENE_1_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 750;
                            ROOM_SCENE_2_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 751;
                            ROOM_SCENE_3_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 752;
                            ROOM_SCENE_4_FB  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 753;
                            ROOM_SCENE_5_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 754;
                            ROOM_SCENE_6_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 755;
                            ROOM_SCENE_7_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 756;
                            ROOM_SCENE_8_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 757;
                            ROOM_SCENE_16_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 758;
                            ROOM_SCENE_OFF_FB  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 5) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 763;
                            if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 765;
                                Print( "Scene 5, String Value {0}\r\n", EXTRACT__DOLLAR__ ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 767;
                            ROOM_SCENE_1_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 768;
                            ROOM_SCENE_2_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 769;
                            ROOM_SCENE_3_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 770;
                            ROOM_SCENE_4_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 771;
                            ROOM_SCENE_5_FB  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 772;
                            ROOM_SCENE_6_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 773;
                            ROOM_SCENE_7_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 774;
                            ROOM_SCENE_8_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 775;
                            ROOM_SCENE_16_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 776;
                            ROOM_SCENE_OFF_FB  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 6) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 781;
                            if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 783;
                                Print( "Scene 6, String Value {0}\r\n", EXTRACT__DOLLAR__ ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 785;
                            ROOM_SCENE_1_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 786;
                            ROOM_SCENE_2_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 787;
                            ROOM_SCENE_3_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 788;
                            ROOM_SCENE_4_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 789;
                            ROOM_SCENE_5_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 790;
                            ROOM_SCENE_6_FB  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 791;
                            ROOM_SCENE_7_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 792;
                            ROOM_SCENE_8_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 793;
                            ROOM_SCENE_16_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 794;
                            ROOM_SCENE_OFF_FB  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 7) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 799;
                            if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 801;
                                Print( "Scene 7, String Value {0}\r\n", EXTRACT__DOLLAR__ ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 803;
                            ROOM_SCENE_1_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 804;
                            ROOM_SCENE_2_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 805;
                            ROOM_SCENE_3_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 806;
                            ROOM_SCENE_4_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 807;
                            ROOM_SCENE_5_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 808;
                            ROOM_SCENE_6_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 809;
                            ROOM_SCENE_7_FB  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 810;
                            ROOM_SCENE_8_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 811;
                            ROOM_SCENE_16_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 812;
                            ROOM_SCENE_OFF_FB  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 8) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 817;
                            if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 819;
                                Print( "Scene 8, String Value {0}\r\n", EXTRACT__DOLLAR__ ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 821;
                            ROOM_SCENE_1_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 822;
                            ROOM_SCENE_2_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 823;
                            ROOM_SCENE_3_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 824;
                            ROOM_SCENE_4_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 825;
                            ROOM_SCENE_5_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 826;
                            ROOM_SCENE_6_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 827;
                            ROOM_SCENE_7_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 828;
                            ROOM_SCENE_8_FB  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 829;
                            ROOM_SCENE_16_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 830;
                            ROOM_SCENE_OFF_FB  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( 16) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 835;
                            if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 837;
                                Print( "Scene 16, String Value {0}\r\n", EXTRACT__DOLLAR__ ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 839;
                            ROOM_SCENE_1_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 840;
                            ROOM_SCENE_2_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 841;
                            ROOM_SCENE_3_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 842;
                            ROOM_SCENE_4_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 843;
                            ROOM_SCENE_5_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 844;
                            ROOM_SCENE_6_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 845;
                            ROOM_SCENE_7_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 846;
                            ROOM_SCENE_8_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 847;
                            ROOM_SCENE_16_FB  .Value = (ushort) ( 1 ) ; 
                            __context__.SourceCodeLine = 848;
                            ROOM_SCENE_OFF_FB  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_4__ == ( ((((((9 | 10) | 11) | 12) | 13) | 14) | 15)) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 853;
                            if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                                { 
                                __context__.SourceCodeLine = 855;
                                Print( "Scene 9-15 , String Value {0}\r\n", EXTRACT__DOLLAR__ ) ; 
                                } 
                            
                            __context__.SourceCodeLine = 857;
                            ROOM_SCENE_1_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 858;
                            ROOM_SCENE_2_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 859;
                            ROOM_SCENE_3_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 860;
                            ROOM_SCENE_4_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 861;
                            ROOM_SCENE_5_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 862;
                            ROOM_SCENE_6_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 863;
                            ROOM_SCENE_7_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 864;
                            ROOM_SCENE_8_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 865;
                            ROOM_SCENE_16_FB  .Value = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 866;
                            ROOM_SCENE_OFF_FB  .Value = (ushort) ( 0 ) ; 
                            } 
                        
                        } 
                        
                    }
                    
                
                } 
            
            __context__.SourceCodeLine = 872;
            if ( Functions.TestForTrue  ( ( Functions.Find( SYNC__DOLLAR__ , PAYLOAD__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 874;
                if ( Functions.TestForTrue  ( ( ENABLE_REPORTING)  ) ) 
                    { 
                    __context__.SourceCodeLine = 876;
                    TOAVBRIDGE  .UpdateValue ( "!filter.2\r"  ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 898;
            if ( Functions.TestForTrue  ( ( Functions.Find( LEVEL__DOLLAR__ , PAYLOAD__DOLLAR__ ))  ) ) 
                { 
                __context__.SourceCodeLine = 900;
                X = (ushort) ( Functions.Find( "." , PAYLOAD__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 901;
                Y = (ushort) ( Functions.Find( "." , PAYLOAD__DOLLAR__ , (X + 1) ) ) ; 
                __context__.SourceCodeLine = 903;
                EXTRACT__DOLLAR__  .UpdateValue ( Functions.Mid ( PAYLOAD__DOLLAR__ ,  (int) ( (X + 1) ) ,  (int) ( (Y - X) ) )  ) ; 
                __context__.SourceCodeLine = 904;
                LID__DOLLAR__  .UpdateValue ( Functions.Mid ( PAYLOAD__DOLLAR__ ,  (int) ( (Y + 2) ) ,  (int) ( 2 ) )  ) ; 
                __context__.SourceCodeLine = 906;
                if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 908;
                    Print( "Level Reporting:\r\n                      payload = {0}                      POS = {1:d}, \r\n                      Level = {2} Load_ID = {3:d}\r\n                      Value sent = {4:d}d\r\n", PAYLOAD__DOLLAR__ , (short)X, EXTRACT__DOLLAR__ , (short)Functions.Atoi( LID__DOLLAR__ ), (ushort)(Functions.Atoi( EXTRACT__DOLLAR__ ) * 655)) ; 
                    } 
                
                __context__.SourceCodeLine = 914;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Atoi( LID__DOLLAR__ ) <= 8 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 916;
                    LOAD_LEVEL_FB_L [ Functions.Atoi( LID__DOLLAR__ )]  .Value = (ushort) ( (Functions.Atoi( EXTRACT__DOLLAR__ ) * 655) ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 925;
            if ( Functions.TestForTrue  ( ( (Functions.Find( LIGHTSON__DOLLAR__ , PAYLOAD__DOLLAR__ ) | Functions.Find( LIGHTSOFF__DOLLAR__ , PAYLOAD__DOLLAR__ )))  ) ) 
                { 
                __context__.SourceCodeLine = 927;
                X = (ushort) ( Functions.Find( "." , PAYLOAD__DOLLAR__ ) ) ; 
                __context__.SourceCodeLine = 928;
                Y = (ushort) ( Functions.Find( "." , PAYLOAD__DOLLAR__ , (X + 1) ) ) ; 
                __context__.SourceCodeLine = 930;
                EXTRACT__DOLLAR__  .UpdateValue ( Functions.Mid ( PAYLOAD__DOLLAR__ ,  (int) ( (Y + 1) ) ,  (int) ( 2 ) )  ) ; 
                __context__.SourceCodeLine = 932;
                if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 934;
                    Print( "Room Lights ON/OFF FB :\r\n     payload = {0}, POS = {1:d}, \r\n     State = {2} \r\n", PAYLOAD__DOLLAR__ , (short)Y, EXTRACT__DOLLAR__ ) ; 
                    } 
                
                __context__.SourceCodeLine = 938;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EXTRACT__DOLLAR__ == "on"))  ) ) 
                    { 
                    __context__.SourceCodeLine = 940;
                    ROOM_IS_ON_FB  .Value = (ushort) ( 1 ) ; 
                    } 
                
                __context__.SourceCodeLine = 942;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (EXTRACT__DOLLAR__ == "of"))  ) ) 
                    { 
                    __context__.SourceCodeLine = 944;
                    ROOM_IS_ON_FB  .Value = (ushort) ( 0 ) ; 
                    } 
                
                } 
            
            else 
                { 
                __context__.SourceCodeLine = 963;
                if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                    { 
                    __context__.SourceCodeLine = 965;
                    Print( "nothing found string was {0}", PAYLOAD__DOLLAR__ ) ; 
                    } 
                
                } 
            
            
            }
            
        private void RECALLSCENE (  SplusExecutionContext __context__, ushort X ) 
            { 
            CrestronString SCENE;
            SCENE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            
            __context__.SourceCodeLine = 976;
            MakeString ( SCENE , "!room.scene.{0:d}\r", (short)X) ; 
            __context__.SourceCodeLine = 977;
            TOAVBRIDGE  .UpdateValue ( SCENE  ) ; 
            
            }
            
        private void SETLOADLVL (  SplusExecutionContext __context__, uint LEVEL , ushort LOAD ) 
            { 
            CrestronString SCENE;
            SCENE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            
            __context__.SourceCodeLine = 984;
            MakeString ( SCENE , "!level.{0:d}.L0{1:d}\r", (short)((LEVEL * 100) / 65535), (short)LOAD) ; 
            __context__.SourceCodeLine = 985;
            TOAVBRIDGE  .UpdateValue ( SCENE  ) ; 
            
            }
            
        private void SETROOMLVL (  SplusExecutionContext __context__, uint LEVEL ) 
            { 
            CrestronString ROOMLVL;
            ROOMLVL  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            
            __context__.SourceCodeLine = 991;
            MakeString ( ROOMLVL , "!level.{0:d}\r", (short)((LEVEL * 100) / 65535)) ; 
            __context__.SourceCodeLine = 992;
            TOAVBRIDGE  .UpdateValue ( ROOMLVL  ) ; 
            
            }
            
        private void SAVESCENE (  SplusExecutionContext __context__, ushort X ) 
            { 
            CrestronString SAVEIT;
            SAVEIT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
            
            
            __context__.SourceCodeLine = 998;
            MakeString ( SAVEIT , "!scenesave.{0:d}\r", (short)X) ; 
            __context__.SourceCodeLine = 999;
            TOAVBRIDGE  .UpdateValue ( SAVEIT  ) ; 
            
            }
            
        object FROMAVBRIDGE_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                CrestronString INCOMMING__DOLLAR__;
                INCOMMING__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 65534, this );
                
                
                __context__.SourceCodeLine = 1023;
                while ( Functions.TestForTrue  ( ( 1)  ) ) 
                    { 
                    __context__.SourceCodeLine = 1025;
                    INCOMMING__DOLLAR__  .UpdateValue ( Functions.Gather ( "\r" , FROMAVBRIDGE )  ) ; 
                    __context__.SourceCodeLine = 1027;
                    if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
                        { 
                        __context__.SourceCodeLine = 1029;
                        Print( "string is: {0}\r\n", INCOMMING__DOLLAR__ ) ; 
                        } 
                    
                    __context__.SourceCodeLine = 1032;
                    PROCESS_MSG (  __context__ , INCOMMING__DOLLAR__) ; 
                    __context__.SourceCodeLine = 1023;
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object ROOM_RECALL_SCENE_1_OnPush_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 1039;
            RECALLSCENE (  __context__ , (ushort)( 1 )) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
object ROOM_RECALL_SCENE_2_OnPush_2 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1044;
        RECALLSCENE (  __context__ , (ushort)( 2 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROOM_RECALL_SCENE_3_OnPush_3 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1049;
        RECALLSCENE (  __context__ , (ushort)( 3 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROOM_RECALL_SCENE_4_OnPush_4 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1053;
        RECALLSCENE (  __context__ , (ushort)( 4 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROOM_RECALL_SCENE_5_OnPush_5 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1057;
        RECALLSCENE (  __context__ , (ushort)( 5 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROOM_RECALL_SCENE_6_OnPush_6 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1061;
        RECALLSCENE (  __context__ , (ushort)( 6 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROOM_RECALL_SCENE_7_OnPush_7 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1065;
        RECALLSCENE (  __context__ , (ushort)( 7 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROOM_RECALL_SCENE_8_OnPush_8 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1069;
        RECALLSCENE (  __context__ , (ushort)( 8 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROOM_RECALL_SCENE_16_OnPush_9 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1074;
        RECALLSCENE (  __context__ , (ushort)( 16 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROOM_RECALL_OFF_OnPush_10 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1079;
        TOAVBRIDGE  .UpdateValue ( "!room.lights.off\r"  ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROOM_SAVE_SCENE_1_OnPush_11 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1086;
        SAVESCENE (  __context__ , (ushort)( 1 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROOM_SAVE_SCENE_2_OnPush_12 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1091;
        SAVESCENE (  __context__ , (ushort)( 2 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROOM_SAVE_SCENE_3_OnPush_13 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1096;
        SAVESCENE (  __context__ , (ushort)( 3 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROOM_SAVE_SCENE_4_OnPush_14 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1101;
        SAVESCENE (  __context__ , (ushort)( 4 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROOM_SAVE_SCENE_5_OnPush_15 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1106;
        SAVESCENE (  __context__ , (ushort)( 5 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROOM_SAVE_SCENE_6_OnPush_16 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1111;
        SAVESCENE (  __context__ , (ushort)( 6 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROOM_SAVE_SCENE_7_OnPush_17 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1116;
        SAVESCENE (  __context__ , (ushort)( 7 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROOM_SAVE_SCENE_8_OnPush_18 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1121;
        SAVESCENE (  __context__ , (ushort)( 8 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROOM_SAVE_SCENE_16_OnPush_19 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1127;
        SAVESCENE (  __context__ , (ushort)( 16 )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ENABLE_LEVEL_FB_OnPush_20 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1135;
        TOAVBRIDGE  .UpdateValue ( "!filter.2\r"  ) ; 
        __context__.SourceCodeLine = 1136;
        ENABLE_REPORTING = (ushort) ( 1 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DISABLE_LEVEL_FB_OnPush_21 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1140;
        TOAVBRIDGE  .UpdateValue ( "!filter.0\r"  ) ; 
        __context__.SourceCodeLine = 1141;
        ENABLE_REPORTING = (ushort) ( 0 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object DIRECT_LEVEL_L_OnChange_22 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        ushort INDEX = 0;
        
        
        __context__.SourceCodeLine = 1149;
        INDEX = (ushort) ( Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ) ; 
        __context__.SourceCodeLine = 1150;
        if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
            { 
            __context__.SourceCodeLine = 1152;
            Print( "Dynamic index {0:d}  has changed to {1:d}\r\n", (short)INDEX, (short)DIRECT_LEVEL_L[ INDEX ] .UshortValue) ; 
            } 
        
        __context__.SourceCodeLine = 1154;
        SETLOADLVL (  __context__ , (uint)( DIRECT_LEVEL_L[ INDEX ] .UintValue ), (ushort)( INDEX )) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler( __SignalEventArg__ ); }
    return this;
    
}

object ROOM_LEVEL_OnChange_23 ( Object __EventInfo__ )

    { 
    Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
    try
    {
        SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
        
        __context__.SourceCodeLine = 1158;
        if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
            { 
            __context__.SourceCodeLine = 1160;
            Print( "Room Level changed to:  {0:d}!\r\n", (short)ROOM_LEVEL  .UshortValue) ; 
            } 
        
        __context__.SourceCodeLine = 1162;
        SETROOMLVL (  __context__ , (uint)( ROOM_LEVEL  .UintValue )) ; 
        
        
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
        
        __context__.SourceCodeLine = 1221;
        WaitForInitializationComplete ( ) ; 
        __context__.SourceCodeLine = 1222;
        TAPTIME = (ushort) ( 50 ) ; 
        __context__.SourceCodeLine = 1223;
        DEBUGMODE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1224;
        DEBUGLEVEL = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 1227;
        BUTTON__DOLLAR__  .UpdateValue ( "button"  ) ; 
        __context__.SourceCodeLine = 1228;
        ROOM__DOLLAR__  .UpdateValue ( "room"  ) ; 
        __context__.SourceCodeLine = 1229;
        SCENE__DOLLAR__  .UpdateValue ( "Scene"  ) ; 
        __context__.SourceCodeLine = 1230;
        DL_ACTION__DOLLAR__  .UpdateValue ( "daylight-action"  ) ; 
        __context__.SourceCodeLine = 1231;
        OCC_ACTION__DOLLAR__  .UpdateValue ( "occ-action"  ) ; 
        __context__.SourceCodeLine = 1232;
        OCCUPANCY__DOLLAR__  .UpdateValue ( "occupancy"  ) ; 
        __context__.SourceCodeLine = 1233;
        ROOM_LIGHTS__DOLLAR__  .UpdateValue ( "scene"  ) ; 
        __context__.SourceCodeLine = 1234;
        LIGHTSOFF__DOLLAR__  .UpdateValue ( "room.lights.off"  ) ; 
        __context__.SourceCodeLine = 1235;
        LIGHTSON__DOLLAR__  .UpdateValue ( "room.lights.on"  ) ; 
        __context__.SourceCodeLine = 1236;
        LEVEL__DOLLAR__  .UpdateValue ( "^level."  ) ; 
        __context__.SourceCodeLine = 1237;
        TAP__DOLLAR__  .UpdateValue ( "tap"  ) ; 
        __context__.SourceCodeLine = 1238;
        HOLD__DOLLAR__  .UpdateValue ( "hold"  ) ; 
        __context__.SourceCodeLine = 1239;
        RELEASE__DOLLAR__  .UpdateValue ( "release"  ) ; 
        __context__.SourceCodeLine = 1240;
        SYNC__DOLLAR__  .UpdateValue ( "sync"  ) ; 
        __context__.SourceCodeLine = 1241;
        if ( Functions.TestForTrue  ( ( DEBUGMODE)  ) ) 
            { 
            __context__.SourceCodeLine = 1243;
            Print( "initialization complete\r\n") ; 
            } 
        
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    _SplusNVRAM = new SplusNVRAM( this );
    TAP__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 15, this );
    HOLD__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 15, this );
    RELEASE__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 15, this );
    BUTTON__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
    ROOM__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
    SCENE__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 15, this );
    DL_ACTION__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    OCC_ACTION__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    LIGHTSON__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    OCCUPANCY__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
    ROOM_LIGHTS__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 30, this );
    LIGHTSOFF__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    LEVEL__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    SYNC__DOLLAR__  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 20, this );
    
    ROOM_RECALL_SCENE_1 = new Crestron.Logos.SplusObjects.DigitalInput( ROOM_RECALL_SCENE_1__DigitalInput__, this );
    m_DigitalInputList.Add( ROOM_RECALL_SCENE_1__DigitalInput__, ROOM_RECALL_SCENE_1 );
    
    ROOM_RECALL_SCENE_2 = new Crestron.Logos.SplusObjects.DigitalInput( ROOM_RECALL_SCENE_2__DigitalInput__, this );
    m_DigitalInputList.Add( ROOM_RECALL_SCENE_2__DigitalInput__, ROOM_RECALL_SCENE_2 );
    
    ROOM_RECALL_SCENE_3 = new Crestron.Logos.SplusObjects.DigitalInput( ROOM_RECALL_SCENE_3__DigitalInput__, this );
    m_DigitalInputList.Add( ROOM_RECALL_SCENE_3__DigitalInput__, ROOM_RECALL_SCENE_3 );
    
    ROOM_RECALL_SCENE_4 = new Crestron.Logos.SplusObjects.DigitalInput( ROOM_RECALL_SCENE_4__DigitalInput__, this );
    m_DigitalInputList.Add( ROOM_RECALL_SCENE_4__DigitalInput__, ROOM_RECALL_SCENE_4 );
    
    ROOM_RECALL_SCENE_5 = new Crestron.Logos.SplusObjects.DigitalInput( ROOM_RECALL_SCENE_5__DigitalInput__, this );
    m_DigitalInputList.Add( ROOM_RECALL_SCENE_5__DigitalInput__, ROOM_RECALL_SCENE_5 );
    
    ROOM_RECALL_SCENE_6 = new Crestron.Logos.SplusObjects.DigitalInput( ROOM_RECALL_SCENE_6__DigitalInput__, this );
    m_DigitalInputList.Add( ROOM_RECALL_SCENE_6__DigitalInput__, ROOM_RECALL_SCENE_6 );
    
    ROOM_RECALL_SCENE_7 = new Crestron.Logos.SplusObjects.DigitalInput( ROOM_RECALL_SCENE_7__DigitalInput__, this );
    m_DigitalInputList.Add( ROOM_RECALL_SCENE_7__DigitalInput__, ROOM_RECALL_SCENE_7 );
    
    ROOM_RECALL_SCENE_8 = new Crestron.Logos.SplusObjects.DigitalInput( ROOM_RECALL_SCENE_8__DigitalInput__, this );
    m_DigitalInputList.Add( ROOM_RECALL_SCENE_8__DigitalInput__, ROOM_RECALL_SCENE_8 );
    
    ROOM_RECALL_SCENE_16 = new Crestron.Logos.SplusObjects.DigitalInput( ROOM_RECALL_SCENE_16__DigitalInput__, this );
    m_DigitalInputList.Add( ROOM_RECALL_SCENE_16__DigitalInput__, ROOM_RECALL_SCENE_16 );
    
    ROOM_RECALL_OFF = new Crestron.Logos.SplusObjects.DigitalInput( ROOM_RECALL_OFF__DigitalInput__, this );
    m_DigitalInputList.Add( ROOM_RECALL_OFF__DigitalInput__, ROOM_RECALL_OFF );
    
    ROOM_SAVE_SCENE_1 = new Crestron.Logos.SplusObjects.DigitalInput( ROOM_SAVE_SCENE_1__DigitalInput__, this );
    m_DigitalInputList.Add( ROOM_SAVE_SCENE_1__DigitalInput__, ROOM_SAVE_SCENE_1 );
    
    ROOM_SAVE_SCENE_2 = new Crestron.Logos.SplusObjects.DigitalInput( ROOM_SAVE_SCENE_2__DigitalInput__, this );
    m_DigitalInputList.Add( ROOM_SAVE_SCENE_2__DigitalInput__, ROOM_SAVE_SCENE_2 );
    
    ROOM_SAVE_SCENE_3 = new Crestron.Logos.SplusObjects.DigitalInput( ROOM_SAVE_SCENE_3__DigitalInput__, this );
    m_DigitalInputList.Add( ROOM_SAVE_SCENE_3__DigitalInput__, ROOM_SAVE_SCENE_3 );
    
    ROOM_SAVE_SCENE_4 = new Crestron.Logos.SplusObjects.DigitalInput( ROOM_SAVE_SCENE_4__DigitalInput__, this );
    m_DigitalInputList.Add( ROOM_SAVE_SCENE_4__DigitalInput__, ROOM_SAVE_SCENE_4 );
    
    ROOM_SAVE_SCENE_5 = new Crestron.Logos.SplusObjects.DigitalInput( ROOM_SAVE_SCENE_5__DigitalInput__, this );
    m_DigitalInputList.Add( ROOM_SAVE_SCENE_5__DigitalInput__, ROOM_SAVE_SCENE_5 );
    
    ROOM_SAVE_SCENE_6 = new Crestron.Logos.SplusObjects.DigitalInput( ROOM_SAVE_SCENE_6__DigitalInput__, this );
    m_DigitalInputList.Add( ROOM_SAVE_SCENE_6__DigitalInput__, ROOM_SAVE_SCENE_6 );
    
    ROOM_SAVE_SCENE_7 = new Crestron.Logos.SplusObjects.DigitalInput( ROOM_SAVE_SCENE_7__DigitalInput__, this );
    m_DigitalInputList.Add( ROOM_SAVE_SCENE_7__DigitalInput__, ROOM_SAVE_SCENE_7 );
    
    ROOM_SAVE_SCENE_8 = new Crestron.Logos.SplusObjects.DigitalInput( ROOM_SAVE_SCENE_8__DigitalInput__, this );
    m_DigitalInputList.Add( ROOM_SAVE_SCENE_8__DigitalInput__, ROOM_SAVE_SCENE_8 );
    
    ROOM_SAVE_SCENE_16 = new Crestron.Logos.SplusObjects.DigitalInput( ROOM_SAVE_SCENE_16__DigitalInput__, this );
    m_DigitalInputList.Add( ROOM_SAVE_SCENE_16__DigitalInput__, ROOM_SAVE_SCENE_16 );
    
    ENABLE_LEVEL_FB = new Crestron.Logos.SplusObjects.DigitalInput( ENABLE_LEVEL_FB__DigitalInput__, this );
    m_DigitalInputList.Add( ENABLE_LEVEL_FB__DigitalInput__, ENABLE_LEVEL_FB );
    
    DISABLE_LEVEL_FB = new Crestron.Logos.SplusObjects.DigitalInput( DISABLE_LEVEL_FB__DigitalInput__, this );
    m_DigitalInputList.Add( DISABLE_LEVEL_FB__DigitalInput__, DISABLE_LEVEL_FB );
    
    ROOM_IS_ON_FB = new Crestron.Logos.SplusObjects.DigitalOutput( ROOM_IS_ON_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( ROOM_IS_ON_FB__DigitalOutput__, ROOM_IS_ON_FB );
    
    ROOM_SCENE_1_FB = new Crestron.Logos.SplusObjects.DigitalOutput( ROOM_SCENE_1_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( ROOM_SCENE_1_FB__DigitalOutput__, ROOM_SCENE_1_FB );
    
    ROOM_SCENE_2_FB = new Crestron.Logos.SplusObjects.DigitalOutput( ROOM_SCENE_2_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( ROOM_SCENE_2_FB__DigitalOutput__, ROOM_SCENE_2_FB );
    
    ROOM_SCENE_3_FB = new Crestron.Logos.SplusObjects.DigitalOutput( ROOM_SCENE_3_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( ROOM_SCENE_3_FB__DigitalOutput__, ROOM_SCENE_3_FB );
    
    ROOM_SCENE_4_FB = new Crestron.Logos.SplusObjects.DigitalOutput( ROOM_SCENE_4_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( ROOM_SCENE_4_FB__DigitalOutput__, ROOM_SCENE_4_FB );
    
    ROOM_SCENE_5_FB = new Crestron.Logos.SplusObjects.DigitalOutput( ROOM_SCENE_5_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( ROOM_SCENE_5_FB__DigitalOutput__, ROOM_SCENE_5_FB );
    
    ROOM_SCENE_6_FB = new Crestron.Logos.SplusObjects.DigitalOutput( ROOM_SCENE_6_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( ROOM_SCENE_6_FB__DigitalOutput__, ROOM_SCENE_6_FB );
    
    ROOM_SCENE_7_FB = new Crestron.Logos.SplusObjects.DigitalOutput( ROOM_SCENE_7_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( ROOM_SCENE_7_FB__DigitalOutput__, ROOM_SCENE_7_FB );
    
    ROOM_SCENE_8_FB = new Crestron.Logos.SplusObjects.DigitalOutput( ROOM_SCENE_8_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( ROOM_SCENE_8_FB__DigitalOutput__, ROOM_SCENE_8_FB );
    
    ROOM_SCENE_16_FB = new Crestron.Logos.SplusObjects.DigitalOutput( ROOM_SCENE_16_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( ROOM_SCENE_16_FB__DigitalOutput__, ROOM_SCENE_16_FB );
    
    ROOM_SCENE_OFF_FB = new Crestron.Logos.SplusObjects.DigitalOutput( ROOM_SCENE_OFF_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( ROOM_SCENE_OFF_FB__DigitalOutput__, ROOM_SCENE_OFF_FB );
    
    ROOM_IS_OCCUPIED_FB = new Crestron.Logos.SplusObjects.DigitalOutput( ROOM_IS_OCCUPIED_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( ROOM_IS_OCCUPIED_FB__DigitalOutput__, ROOM_IS_OCCUPIED_FB );
    
    ROOM_DAYLIGHTING_ENABLED_FB = new Crestron.Logos.SplusObjects.DigitalOutput( ROOM_DAYLIGHTING_ENABLED_FB__DigitalOutput__, this );
    m_DigitalOutputList.Add( ROOM_DAYLIGHTING_ENABLED_FB__DigitalOutput__, ROOM_DAYLIGHTING_ENABLED_FB );
    
    KP_01_BUTTON_TAP = new InOutArray<DigitalOutput>( 6, this );
    for( uint i = 0; i < 6; i++ )
    {
        KP_01_BUTTON_TAP[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( KP_01_BUTTON_TAP__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( KP_01_BUTTON_TAP__DigitalOutput__ + i, KP_01_BUTTON_TAP[i+1] );
    }
    
    KP_01_BUTTON_HOLD = new InOutArray<DigitalOutput>( 6, this );
    for( uint i = 0; i < 6; i++ )
    {
        KP_01_BUTTON_HOLD[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( KP_01_BUTTON_HOLD__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( KP_01_BUTTON_HOLD__DigitalOutput__ + i, KP_01_BUTTON_HOLD[i+1] );
    }
    
    KP_02_BUTTON_TAP = new InOutArray<DigitalOutput>( 6, this );
    for( uint i = 0; i < 6; i++ )
    {
        KP_02_BUTTON_TAP[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( KP_02_BUTTON_TAP__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( KP_02_BUTTON_TAP__DigitalOutput__ + i, KP_02_BUTTON_TAP[i+1] );
    }
    
    KP_02_BUTTON_HOLD = new InOutArray<DigitalOutput>( 6, this );
    for( uint i = 0; i < 6; i++ )
    {
        KP_02_BUTTON_HOLD[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( KP_02_BUTTON_HOLD__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( KP_02_BUTTON_HOLD__DigitalOutput__ + i, KP_02_BUTTON_HOLD[i+1] );
    }
    
    KP_03_BUTTON_TAP = new InOutArray<DigitalOutput>( 6, this );
    for( uint i = 0; i < 6; i++ )
    {
        KP_03_BUTTON_TAP[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( KP_03_BUTTON_TAP__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( KP_03_BUTTON_TAP__DigitalOutput__ + i, KP_03_BUTTON_TAP[i+1] );
    }
    
    KP_03_BUTTON_HOLD = new InOutArray<DigitalOutput>( 6, this );
    for( uint i = 0; i < 6; i++ )
    {
        KP_03_BUTTON_HOLD[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( KP_03_BUTTON_HOLD__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( KP_03_BUTTON_HOLD__DigitalOutput__ + i, KP_03_BUTTON_HOLD[i+1] );
    }
    
    KP_04_BUTTON_TAP = new InOutArray<DigitalOutput>( 6, this );
    for( uint i = 0; i < 6; i++ )
    {
        KP_04_BUTTON_TAP[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( KP_04_BUTTON_TAP__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( KP_04_BUTTON_TAP__DigitalOutput__ + i, KP_04_BUTTON_TAP[i+1] );
    }
    
    KP_04_BUTTON_HOLD = new InOutArray<DigitalOutput>( 6, this );
    for( uint i = 0; i < 6; i++ )
    {
        KP_04_BUTTON_HOLD[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( KP_04_BUTTON_HOLD__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( KP_04_BUTTON_HOLD__DigitalOutput__ + i, KP_04_BUTTON_HOLD[i+1] );
    }
    
    KP_05_BUTTON_TAP = new InOutArray<DigitalOutput>( 6, this );
    for( uint i = 0; i < 6; i++ )
    {
        KP_05_BUTTON_TAP[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( KP_05_BUTTON_TAP__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( KP_05_BUTTON_TAP__DigitalOutput__ + i, KP_05_BUTTON_TAP[i+1] );
    }
    
    KP_05_BUTTON_HOLD = new InOutArray<DigitalOutput>( 6, this );
    for( uint i = 0; i < 6; i++ )
    {
        KP_05_BUTTON_HOLD[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( KP_05_BUTTON_HOLD__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( KP_05_BUTTON_HOLD__DigitalOutput__ + i, KP_05_BUTTON_HOLD[i+1] );
    }
    
    KP_06_BUTTON_TAP = new InOutArray<DigitalOutput>( 6, this );
    for( uint i = 0; i < 6; i++ )
    {
        KP_06_BUTTON_TAP[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( KP_06_BUTTON_TAP__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( KP_06_BUTTON_TAP__DigitalOutput__ + i, KP_06_BUTTON_TAP[i+1] );
    }
    
    KP_06_BUTTON_HOLD = new InOutArray<DigitalOutput>( 6, this );
    for( uint i = 0; i < 6; i++ )
    {
        KP_06_BUTTON_HOLD[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( KP_06_BUTTON_HOLD__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( KP_06_BUTTON_HOLD__DigitalOutput__ + i, KP_06_BUTTON_HOLD[i+1] );
    }
    
    KP_07_BUTTON_TAP = new InOutArray<DigitalOutput>( 6, this );
    for( uint i = 0; i < 6; i++ )
    {
        KP_07_BUTTON_TAP[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( KP_07_BUTTON_TAP__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( KP_07_BUTTON_TAP__DigitalOutput__ + i, KP_07_BUTTON_TAP[i+1] );
    }
    
    KP_07_BUTTON_HOLD = new InOutArray<DigitalOutput>( 6, this );
    for( uint i = 0; i < 6; i++ )
    {
        KP_07_BUTTON_HOLD[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( KP_07_BUTTON_HOLD__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( KP_07_BUTTON_HOLD__DigitalOutput__ + i, KP_07_BUTTON_HOLD[i+1] );
    }
    
    KP_08_BUTTON_TAP = new InOutArray<DigitalOutput>( 6, this );
    for( uint i = 0; i < 6; i++ )
    {
        KP_08_BUTTON_TAP[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( KP_08_BUTTON_TAP__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( KP_08_BUTTON_TAP__DigitalOutput__ + i, KP_08_BUTTON_TAP[i+1] );
    }
    
    KP_08_BUTTON_HOLD = new InOutArray<DigitalOutput>( 6, this );
    for( uint i = 0; i < 6; i++ )
    {
        KP_08_BUTTON_HOLD[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( KP_08_BUTTON_HOLD__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( KP_08_BUTTON_HOLD__DigitalOutput__ + i, KP_08_BUTTON_HOLD[i+1] );
    }
    
    ROOM_LEVEL = new Crestron.Logos.SplusObjects.AnalogInput( ROOM_LEVEL__AnalogSerialInput__, this );
    m_AnalogInputList.Add( ROOM_LEVEL__AnalogSerialInput__, ROOM_LEVEL );
    
    DIRECT_LEVEL_L = new InOutArray<AnalogInput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        DIRECT_LEVEL_L[i+1] = new Crestron.Logos.SplusObjects.AnalogInput( DIRECT_LEVEL_L__AnalogSerialInput__ + i, DIRECT_LEVEL_L__AnalogSerialInput__, this );
        m_AnalogInputList.Add( DIRECT_LEVEL_L__AnalogSerialInput__ + i, DIRECT_LEVEL_L[i+1] );
    }
    
    LOAD_LEVEL_FB_L = new InOutArray<AnalogOutput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        LOAD_LEVEL_FB_L[i+1] = new Crestron.Logos.SplusObjects.AnalogOutput( LOAD_LEVEL_FB_L__AnalogSerialOutput__ + i, this );
        m_AnalogOutputList.Add( LOAD_LEVEL_FB_L__AnalogSerialOutput__ + i, LOAD_LEVEL_FB_L[i+1] );
    }
    
    TOAVBRIDGE = new Crestron.Logos.SplusObjects.StringOutput( TOAVBRIDGE__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TOAVBRIDGE__AnalogSerialOutput__, TOAVBRIDGE );
    
    FROMAVBRIDGE = new Crestron.Logos.SplusObjects.BufferInput( FROMAVBRIDGE__AnalogSerialInput__, 65534, this );
    m_StringInputList.Add( FROMAVBRIDGE__AnalogSerialInput__, FROMAVBRIDGE );
    
    
    FROMAVBRIDGE.OnSerialChange.Add( new InputChangeHandlerWrapper( FROMAVBRIDGE_OnChange_0, true ) );
    ROOM_RECALL_SCENE_1.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROOM_RECALL_SCENE_1_OnPush_1, false ) );
    ROOM_RECALL_SCENE_2.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROOM_RECALL_SCENE_2_OnPush_2, false ) );
    ROOM_RECALL_SCENE_3.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROOM_RECALL_SCENE_3_OnPush_3, false ) );
    ROOM_RECALL_SCENE_4.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROOM_RECALL_SCENE_4_OnPush_4, false ) );
    ROOM_RECALL_SCENE_5.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROOM_RECALL_SCENE_5_OnPush_5, false ) );
    ROOM_RECALL_SCENE_6.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROOM_RECALL_SCENE_6_OnPush_6, false ) );
    ROOM_RECALL_SCENE_7.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROOM_RECALL_SCENE_7_OnPush_7, false ) );
    ROOM_RECALL_SCENE_8.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROOM_RECALL_SCENE_8_OnPush_8, false ) );
    ROOM_RECALL_SCENE_16.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROOM_RECALL_SCENE_16_OnPush_9, false ) );
    ROOM_RECALL_OFF.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROOM_RECALL_OFF_OnPush_10, false ) );
    ROOM_SAVE_SCENE_1.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROOM_SAVE_SCENE_1_OnPush_11, false ) );
    ROOM_SAVE_SCENE_2.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROOM_SAVE_SCENE_2_OnPush_12, false ) );
    ROOM_SAVE_SCENE_3.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROOM_SAVE_SCENE_3_OnPush_13, false ) );
    ROOM_SAVE_SCENE_4.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROOM_SAVE_SCENE_4_OnPush_14, false ) );
    ROOM_SAVE_SCENE_5.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROOM_SAVE_SCENE_5_OnPush_15, false ) );
    ROOM_SAVE_SCENE_6.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROOM_SAVE_SCENE_6_OnPush_16, false ) );
    ROOM_SAVE_SCENE_7.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROOM_SAVE_SCENE_7_OnPush_17, false ) );
    ROOM_SAVE_SCENE_8.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROOM_SAVE_SCENE_8_OnPush_18, false ) );
    ROOM_SAVE_SCENE_16.OnDigitalPush.Add( new InputChangeHandlerWrapper( ROOM_SAVE_SCENE_16_OnPush_19, false ) );
    ENABLE_LEVEL_FB.OnDigitalPush.Add( new InputChangeHandlerWrapper( ENABLE_LEVEL_FB_OnPush_20, false ) );
    DISABLE_LEVEL_FB.OnDigitalPush.Add( new InputChangeHandlerWrapper( DISABLE_LEVEL_FB_OnPush_21, false ) );
    for( uint i = 0; i < 8; i++ )
        DIRECT_LEVEL_L[i+1].OnAnalogChange.Add( new InputChangeHandlerWrapper( DIRECT_LEVEL_L_OnChange_22, false ) );
        
    ROOM_LEVEL.OnAnalogChange.Add( new InputChangeHandlerWrapper( ROOM_LEVEL_OnChange_23, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public CrestronModuleClass_ZUM_AV_BRIDGE_MODULE__EXPANDED__V1_1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint ROOM_RECALL_SCENE_1__DigitalInput__ = 0;
const uint ROOM_RECALL_SCENE_2__DigitalInput__ = 1;
const uint ROOM_RECALL_SCENE_3__DigitalInput__ = 2;
const uint ROOM_RECALL_SCENE_4__DigitalInput__ = 3;
const uint ROOM_RECALL_SCENE_5__DigitalInput__ = 4;
const uint ROOM_RECALL_SCENE_6__DigitalInput__ = 5;
const uint ROOM_RECALL_SCENE_7__DigitalInput__ = 6;
const uint ROOM_RECALL_SCENE_8__DigitalInput__ = 7;
const uint ROOM_RECALL_SCENE_16__DigitalInput__ = 8;
const uint ROOM_RECALL_OFF__DigitalInput__ = 9;
const uint ROOM_SAVE_SCENE_1__DigitalInput__ = 10;
const uint ROOM_SAVE_SCENE_2__DigitalInput__ = 11;
const uint ROOM_SAVE_SCENE_3__DigitalInput__ = 12;
const uint ROOM_SAVE_SCENE_4__DigitalInput__ = 13;
const uint ROOM_SAVE_SCENE_5__DigitalInput__ = 14;
const uint ROOM_SAVE_SCENE_6__DigitalInput__ = 15;
const uint ROOM_SAVE_SCENE_7__DigitalInput__ = 16;
const uint ROOM_SAVE_SCENE_8__DigitalInput__ = 17;
const uint ROOM_SAVE_SCENE_16__DigitalInput__ = 18;
const uint ROOM_IS_ON_FB__DigitalOutput__ = 0;
const uint ROOM_SCENE_1_FB__DigitalOutput__ = 1;
const uint ROOM_SCENE_2_FB__DigitalOutput__ = 2;
const uint ROOM_SCENE_3_FB__DigitalOutput__ = 3;
const uint ROOM_SCENE_4_FB__DigitalOutput__ = 4;
const uint ROOM_SCENE_5_FB__DigitalOutput__ = 5;
const uint ROOM_SCENE_6_FB__DigitalOutput__ = 6;
const uint ROOM_SCENE_7_FB__DigitalOutput__ = 7;
const uint ROOM_SCENE_8_FB__DigitalOutput__ = 8;
const uint ROOM_SCENE_16_FB__DigitalOutput__ = 9;
const uint ROOM_SCENE_OFF_FB__DigitalOutput__ = 10;
const uint ROOM_IS_OCCUPIED_FB__DigitalOutput__ = 11;
const uint ROOM_DAYLIGHTING_ENABLED_FB__DigitalOutput__ = 12;
const uint ENABLE_LEVEL_FB__DigitalInput__ = 19;
const uint DISABLE_LEVEL_FB__DigitalInput__ = 20;
const uint KP_01_BUTTON_TAP__DigitalOutput__ = 13;
const uint KP_01_BUTTON_HOLD__DigitalOutput__ = 19;
const uint KP_02_BUTTON_TAP__DigitalOutput__ = 25;
const uint KP_02_BUTTON_HOLD__DigitalOutput__ = 31;
const uint KP_03_BUTTON_TAP__DigitalOutput__ = 37;
const uint KP_03_BUTTON_HOLD__DigitalOutput__ = 43;
const uint KP_04_BUTTON_TAP__DigitalOutput__ = 49;
const uint KP_04_BUTTON_HOLD__DigitalOutput__ = 55;
const uint KP_05_BUTTON_TAP__DigitalOutput__ = 61;
const uint KP_05_BUTTON_HOLD__DigitalOutput__ = 67;
const uint KP_06_BUTTON_TAP__DigitalOutput__ = 73;
const uint KP_06_BUTTON_HOLD__DigitalOutput__ = 79;
const uint KP_07_BUTTON_TAP__DigitalOutput__ = 85;
const uint KP_07_BUTTON_HOLD__DigitalOutput__ = 91;
const uint KP_08_BUTTON_TAP__DigitalOutput__ = 97;
const uint KP_08_BUTTON_HOLD__DigitalOutput__ = 103;
const uint FROMAVBRIDGE__AnalogSerialInput__ = 0;
const uint ROOM_LEVEL__AnalogSerialInput__ = 1;
const uint DIRECT_LEVEL_L__AnalogSerialInput__ = 2;
const uint TOAVBRIDGE__AnalogSerialOutput__ = 0;
const uint LOAD_LEVEL_FB_L__AnalogSerialOutput__ = 1;

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
