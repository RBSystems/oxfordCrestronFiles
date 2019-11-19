namespace CCI_Library;
        // class declarations
         class FileUtil;
         class CrestronSimplPlusHelper;
         class ByteBuffer;
         class StringUtil;
    static class FileUtil 
    {
        // class delegates

        // class events

        // class functions
        static STRING_FUNCTION ReadFile ( STRING path );
        static FUNCTION WriteFile ( STRING path , STRING str );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class CrestronSimplPlusHelper 
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

     class ByteBuffer 
    {
        // class delegates

        // class events

        // class functions
        FUNCTION Clear ();
        SIGNED_LONG_INTEGER_FUNCTION Length ();
        SIGNED_LONG_INTEGER_FUNCTION IndexOf ( STRING search );
        STRING_FUNCTION Substring ( SIGNED_LONG_INTEGER startIndex , SIGNED_LONG_INTEGER count );
        STRING_FUNCTION ToString ();
        FUNCTION Delete ( SIGNED_LONG_INTEGER startIndex , SIGNED_LONG_INTEGER count );
        FUNCTION Remove ( SIGNED_LONG_INTEGER startIndex , STRING item );
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

     class StringUtil 
    {
        // class delegates

        // class events

        // class functions
        static STRING_FUNCTION getBoundString ( STRING msg , STRING startChar , STRING stopChar );
        static STRING_FUNCTION convertEncodingUnicode ( STRING msg );
        static STRING_FUNCTION convertEncodingBigEndian ( STRING msg );
        static STRING_FUNCTION htmlEncoding ( STRING msg );
        static STRING_FUNCTION encode ( STRING msg , INTEGER size );
        STRING_FUNCTION ToString ();
        SIGNED_LONG_INTEGER_FUNCTION GetHashCode ();

        // class variables
        INTEGER __class_id__;

        // class properties
    };

