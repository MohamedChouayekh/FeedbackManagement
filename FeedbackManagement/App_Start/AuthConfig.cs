namespace FeedbackManagement.App_Start
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // On commente / supprime l'initialisation de SimpleMembership
            // WebSecurity.InitializeDatabaseConnection(...);
            // ← tout ce qui était ici est désactivé temporairement

            // Tu pourras le remettre plus tard quand tu auras créé la table Users
        }
    }
}