﻿using System;
using Newtonsoft.Json;

namespace Deepgram.Transcription
{
    public class Words
    {
        /// <summary>
        /// Distinct word heard by the model.
        /// </summary>
        [JsonProperty("word")]
        public string Word { get; set; } = string.Empty;

        /// <summary>
        /// Offset in seconds from the start of the audio to where the spoken word starts.
        /// </summary>
        [JsonProperty("start")]
        public decimal Start { get; set; }

        /// <summary>
        /// Offset in seconds from the start of the audio to where the spoken word ends.
        /// </summary>
        [JsonProperty("end")]
        public decimal End { get; set; }

        /// <summary>
        /// Value between 0 and 1 indicating the model's relative confidence in this word.
        /// </summary>
        [JsonProperty("confidence")]
        public decimal Confidence { get; set; }

        /// <summary>
        /// Punctuated version of the word
        /// </summary>
        [JsonProperty("punctuated_word")]
        public string PunctuatedWord { get; set; }
    }
}
