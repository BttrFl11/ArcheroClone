public static class GameConst
{
    public const int MAIN_MENU_ID = 0;
    public const string HORIZONTAL_AXIS = "Horizontal";
    public const string VERTICAL_AXIS = "Vertical";

#if UNITY_EDITOR || UNITY_STANDALONE
    public const bool IS_MOBILE = false;
#else
    public const bool IS_MOBILE = true;
#endif
}
