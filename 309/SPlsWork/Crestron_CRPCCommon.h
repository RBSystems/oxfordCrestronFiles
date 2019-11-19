namespace Crestron.CRPC.Common;
        // class declarations
         class CrpcPropertyAttribute;
         class CrpcMethodAttribute;
         class JSONRPCResponse;
         class ShuffleState;
         class CrpcEventArgs;
         class MediaPlayerBusyEventArgs;
         class MediaPlayerStateChangedEventArgs;
         class MediaPlayerStatusMsgEventArgs;
         class MediaPlayerStateChangedByBrowseContextEventArgs;
         class RepeatState;
         class CrpcObjectAttribute;
         class MenuUpdateEventArgs;
         class MenuClearEventArgs;
         class MenuBusyEventArgs;
         class MenuStateChangedEventArgs;
         class MenuStatusMsgEventArgs;
         class CrpcCategoryAttribute;
         class MediaPlayerEventConstants;
         class MenuItem;
         class MediaPlayerStatusMsg;
         class MediaPlayerBusy;
         class MediaPlayerRating;
         class LogLevel;
         class ObjectDirectoryChangedEventArgs;
         class PlayerIcon;
         class MenuBusy;
         class MenuStatusMsg;
         class CrpcEventAttribute;
         class Access;
    static class ShuffleState // enum
    {
        static SIGNED_LONG_INTEGER Off;
        static SIGNED_LONG_INTEGER Track;
        static SIGNED_LONG_INTEGER Album;
    };

     class CrpcEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class MediaPlayerStateChangedEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

    static class RepeatState // enum
    {
        static SIGNED_LONG_INTEGER Off;
        static SIGNED_LONG_INTEGER Track;
        static SIGNED_LONG_INTEGER All;
    };

     class MenuClearEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class MenuStateChangedEventArgs 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

    static class MediaPlayerEventConstants 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static STRING text[];
        static STRING timeoutSec[];
        static STRING userInputRequired[];
        static STRING initialUserInput[];
        static STRING show[];
        static STRING textForItems[];
        static STRING localExit[];
        static STRING on[];
        static STRING instance[];
        static STRING item[];
        static STRING count[];

        // class properties
    };

     class MenuItem 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING L1[];
        STRING L2[];
        STRING URL[];
    };

     class MediaPlayerStatusMsg 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING text[];
        SIGNED_LONG_INTEGER timeoutSec;
        STRING userInputRequired[];
        STRING initialUserInput[];
        STRING textForItems[][];
    };

     class MediaPlayerBusy 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SIGNED_LONG_INTEGER timeoutSec;
    };

     class MediaPlayerRating 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SIGNED_LONG_INTEGER current;
        SIGNED_LONG_INTEGER max;
        SIGNED_LONG_INTEGER system;
    };

    static class LogLevel // enum
    {
        static SIGNED_LONG_INTEGER Off;
        static SIGNED_LONG_INTEGER Error;
        static SIGNED_LONG_INTEGER Warning;
        static SIGNED_LONG_INTEGER Info;
        static SIGNED_LONG_INTEGER Verbose;
    };

    static class PlayerIcon // enum
    {
        static SIGNED_LONG_INTEGER Default;
        static SIGNED_LONG_INTEGER XM;
        static SIGNED_LONG_INTEGER Sirius;
        static SIGNED_LONG_INTEGER AMFM;
        static SIGNED_LONG_INTEGER ADMS;
        static SIGNED_LONG_INTEGER iPod;
        static SIGNED_LONG_INTEGER InternetRadio;
        static SIGNED_LONG_INTEGER SatelliteRadio;
        static SIGNED_LONG_INTEGER Pandora;
        static SIGNED_LONG_INTEGER Librivox;
    };

     class MenuBusy 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SIGNED_LONG_INTEGER timeoutSec;
    };

     class MenuStatusMsg 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING text[];
        SIGNED_LONG_INTEGER timeoutSec;
        STRING userInputRequired[];
        STRING initialUserInput[];
        STRING textForItems[][];
    };

    static class Access // enum
    {
        static SIGNED_LONG_INTEGER Public;
        static SIGNED_LONG_INTEGER Private;
    };

namespace Crestron.CRPC;
        // class declarations
         class CrpcInterfaceAttribute;
         class CrpcMemberInfoParamsAttribute;
         class CrpcMemberAttribute;
         class CrpcMemberInfoAttribute;
     class CrpcInterfaceAttribute 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Name[];
        STRING Version[];
        STRING Id[];
    };

     class CrpcMemberAttribute 
    {
        // class delegates

        // class events

        // class functions
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();
        STRING_FUNCTION ToString ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING Name[];
    };

