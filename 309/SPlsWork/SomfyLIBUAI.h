namespace SomfyLIBUAI;
        // class declarations
         class TelnetTransportComm;
         class Builder;
         class Parameter;
         class TargetParameter;
         class GroupParameter;
         class PositionParameter;
         class TypeParameter;
         class DirectionParameter;
         class ValueParameter;
         class NumParameter;
         class SeqParameter;
         class Component;
         class DirectionMap;
         class ComponentUtil;
         class MethodMap;
         class RS232TransportComm;
         class ParamMap;
         class TypeMap;
         class Request;
         class InterfaceMap;
         class SystemMap;
         class Response;
         class StandardResponse;
         class SeqResponse;
         class SeqResult;
         class HeartbeatResponse;
         class ErrorResponse;
         class SomfyUAI;
     class TelnetTransportComm 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION SetIPAddress ( STRING ip );
        FUNCTION Connect ();
        FUNCTION Disconnect ();
        FUNCTION SendMessage ( STRING msg );
        FUNCTION Dispose ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

    static class Builder 
    {
        // class delegates

        // class events

        // class functions
        static STRING_FUNCTION GetMethod ( SystemMap system , InterfaceMap interface , MethodMap method );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class Parameter 
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

     class Component 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION ProcessSeqResponse ( SeqResponse response );
        FUNCTION Poll ();
        FUNCTION Reinitialize ();
        FUNCTION Refresh ();
        FUNCTION Dispose ();
        FUNCTION GetInitialized ();
        FUNCTION ProcessResponse ( Request request , Response response );
        FUNCTION StartPositionPoll ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING deviceID[];
        STRING groupID[];

        // class properties
        SIGNED_LONG_INTEGER id;
        INTEGER seqID;
        INTEGER commandProcessorID;
    };

     class DirectionMap 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static DirectionMap UP;
        static DirectionMap DOWN;

        // class properties
        SIGNED_LONG_INTEGER index;
        STRING cmd[];
    };

     class ComponentUtil 
    {
        // class delegates

        // class events

        // class functions
        static FUNCTION Register ( Component me );
        static FUNCTION GetNextSeqID ( Component me );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class MethodMap 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static MethodMap PING;
        static MethodMap PING_COUNT;
        static MethodMap PING_REQ;
        static MethodMap INFO;
        static MethodMap POSITION;
        static MethodMap END_LIMIT;
        static MethodMap STOP;
        static MethodMap UP;
        static MethodMap DOWN;
        static MethodMap TO;
        static MethodMap RELATIVE;
        static MethodMap TILT_UP;
        static MethodMap TILT_DN;
        static MethodMap NEXT;
        static MethodMap PREV;
        static MethodMap IP;
        static MethodMap GET;
        static MethodMap SET;
        static MethodMap MEMBERS;
        static MethodMap RUN;
        static MethodMap LIST;

        // class properties
        SIGNED_LONG_INTEGER index;
        STRING cmd[];
        SIGNED_LONG_INTEGER id;
    };

     class ParamMap 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static ParamMap TARGET;
        static ParamMap GROUP;
        static ParamMap POSITION;
        static ParamMap TYPE;
        static ParamMap VALUE;
        static ParamMap DIRECTION;
        static ParamMap NUM;
        static ParamMap SEQ;

        // class properties
        SIGNED_LONG_INTEGER index;
        STRING cmd[];
    };

     class TypeMap 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static TypeMap PERCENT;
        static TypeMap PULSE;
        static TypeMap PERCENT_INVERT;
        static TypeMap MS;
        static TypeMap PULSES;

        // class properties
        SIGNED_LONG_INTEGER index;
        STRING cmd[];
    };

     class InterfaceMap 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static InterfaceMap STATUS;
        static InterfaceMap MOVE;
        static InterfaceMap GROUP;
        static InterfaceMap SCENE;

        // class properties
        SIGNED_LONG_INTEGER index;
        STRING cmd[];
    };

     class SystemMap 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static SystemMap MYLINK;
        static SystemMap UAI;

        // class properties
        SIGNED_LONG_INTEGER index;
        STRING cmd[];
    };

     class Response 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SIGNED_LONG_INTEGER id;
    };

     class StandardResponse 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING result[];
        SIGNED_LONG_INTEGER id;
    };

     class SeqResponse 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        STRING method[];
        SeqResult params;
        SIGNED_LONG_INTEGER id;
    };

     class SeqResult 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        INTEGER seq;
        INTEGER position;
    };

     class HeartbeatResponse 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SIGNED_LONG_INTEGER id;
    };

     class ErrorResponse 
    {
        // class delegates

        // class events

        // class functions
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
        SIGNED_LONG_INTEGER error;
        SIGNED_LONG_INTEGER id;
    };

     class SomfyUAI 
    {
        // class delegates
        delegate FUNCTION StringCallback ( SIMPLSHARPSTRING msg );
        delegate FUNCTION IntegerCallback ( INTEGER value );

        // class events

        // class functions
        FUNCTION Debug ( STRING msg );
        FUNCTION Connect ();
        FUNCTION Disconnect ();
        FUNCTION Initialize ( INTEGER state );
        FUNCTION Configure ( INTEGER type , INTEGER commandProcessorID , STRING ip , STRING username , STRING password , INTEGER pollTime );
        FUNCTION RS232Response ( STRING msg );
        FUNCTION EnablePoll ( INTEGER state );
        FUNCTION EnableDebug ( INTEGER state );
        FUNCTION Poll ();
        FUNCTION FailedResponse ();
        SIGNED_LONG_INTEGER_FUNCTION GetHeartbeatTime ();
        FUNCTION GetInitialized ();
        SIGNED_LONG_INTEGER_FUNCTION GetResponseTime ();
        FUNCTION Reconnect ();
        FUNCTION SendHeartbeat ();
        FUNCTION Strikeout ();
        FUNCTION sendTrace ( STRING msg );
        FUNCTION ProcessResponse ( Request request , Response response );
        FUNCTION StartPositionPoll ();
        FUNCTION Enqueue ( Request request );
        FUNCTION ErrorChange ( STRING error );
        FUNCTION DataReceived ( STRING msg , SIGNED_LONG_INTEGER length );
        FUNCTION ToDevice ( STRING msg );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        static SIGNED_LONG_INTEGER CMD_QUEUE;
        static SIGNED_LONG_INTEGER POLL_QUEUE;

        // class properties
        DelegateProperty StringCallback SendDebug;
        DelegateProperty IntegerCallback ClientSocketStatus;
        DelegateProperty IntegerCallback OnInitializeChange;
        DelegateProperty IntegerCallback OnCommunicatingChange;
        DelegateProperty StringCallback OnRS232Transmit;
        DelegateProperty StringCallback OnError;
        INTEGER listenerID;
    };

namespace SomfyLIBUAI.Components;
        // class declarations
         class EndpointComponent;
           class IntegerCallback;
     class EndpointComponent 
    {
        // class delegates
        delegate FUNCTION IntegerCallback ( INTEGER value );

        // class events

        // class functions
        FUNCTION Configure ( INTEGER commandProcessorID , INTEGER type , STRING deviceID , STRING groupID );
        FUNCTION StatusPing ();
        FUNCTION StatusInfo ();
        FUNCTION StatusPosition ();
        FUNCTION MoveUp ();
        FUNCTION MoveDown ();
        FUNCTION MoveStop ();
        FUNCTION MoveTo ( INTEGER position );
        FUNCTION MoveRelativeUp ( INTEGER value );
        FUNCTION MoveRelativeDown ( INTEGER value );
        FUNCTION MoveIPNext ();
        FUNCTION MoveIPPrev ();
        FUNCTION MoveIP ( INTEGER num );
        FUNCTION Poll ();
        FUNCTION Reinitialize ();
        FUNCTION Refresh ();
        FUNCTION Dispose ();
        FUNCTION GetInitialized ();
        FUNCTION ProcessResponse ( Request request , Response response );
        FUNCTION ProcessSeqResponse ( SeqResponse response );
        FUNCTION StartPositionPoll ();
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        STRING deviceID[];
        STRING groupID[];

        // class properties
        DelegateProperty IntegerCallback OnInitializeChange;
        DelegateProperty IntegerCallback OnPositionChange;
        SIGNED_LONG_INTEGER id;
        INTEGER seqID;
        INTEGER commandProcessorID;
    };

