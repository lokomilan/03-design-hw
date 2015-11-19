using System;
using NHunspell;

namespace _03_design_hw
{
    public class Word
    {
        private readonly string _nativeForm;
        public string Stem;

        public Word(string nativeForm)
        {
            _nativeForm = nativeForm;
            Stem = GetStem();
        }

        private String GetStem()
        {
            var affFile = "en_US.aff";
            var dictFile = "en_US.dic";
            var hunspell = new Hunspell(affFile, dictFile);
            var stemList = hunspell.Stem(_nativeForm);
            stemList.Reverse();
            stemList.Add(_nativeForm);
            return stemList[0];
        }
    }
}
