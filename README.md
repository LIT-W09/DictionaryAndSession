# DictionaryAndSession

You need to add the following lines of code to enable Session:

https://github.com/LIT-W09/DictionaryAndSession/blob/master/WebApplication17/Startup.cs#L27

https://github.com/LIT-W09/DictionaryAndSession/blob/master/WebApplication17/Startup.cs#L43

Also, to add any arbitrary C# object to session, use the following extension method (you'll first need to install the Newtonsoft.Json library via Nuget):

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            string value = session.GetString(key);

            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }
    }
