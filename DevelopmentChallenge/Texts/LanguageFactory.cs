using System.Collections.Generic;

namespace DevelopmentChallenge.Texts
{
    public class LanguageFactory
    {
        private IDictionary<Entities.LanguageType, ILanguage> _languages;

        public LanguageFactory()
        {
            this._languages = new Dictionary<Entities.LanguageType, ILanguage>
            {
                { Entities.LanguageType.Castellano, new Castellano() },
                { Entities.LanguageType.Ingles, new Ingles() },
                { Entities.LanguageType.Italiano, new Italiano() },
            };
        }

        public ILanguage Get(Entities.LanguageType languageType)
        {
            ILanguage language = this._languages[languageType];

            return language;
        }
    }
}
