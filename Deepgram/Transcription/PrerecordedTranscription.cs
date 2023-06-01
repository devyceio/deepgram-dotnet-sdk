﻿using System;
using Newtonsoft.Json;

namespace Deepgram.Transcription
{
    public class PrerecordedTranscription
    {
        /// <summary>
        /// Metadata for the request
        /// </summary>
        [JsonProperty("metadata")]
        public PrerecordedTranscriptionMetaData MetaData { get; set; } = null;

        /// <summary>
        /// Results of the transcription
        /// </summary>
        [JsonProperty("results")]
        public PrerecordedTranscriptionResult Results { get; set; } = null;


        public string ToWebVTT()
        {
            if (this.Results == null || this.Results.Utterances == null)
            {
                throw new Exception(
                  "This method requires a transcript that was generated with the utterances feature."
                );
            }

            var webVTT = "WEBVTT\n\n";

            if (MetaData != null) { 
                webVTT += $"NOTE\nTranscription provided by Deepgram\nRequest Id: { MetaData.Id}\nCreated: { MetaData.Created}\nDuration: { Math.Round(MetaData.Duration, 3)}\nChannels: { MetaData.Channels}\n\n";
            }

            int index = 1;
            foreach (var utterance in this.Results.Utterances)
            {
                var start = SecondsToTimestamp(utterance.Start);
                var end = SecondsToTimestamp(utterance.End);
                webVTT += $"{index}\n{start} --> {end}\n - {utterance.Transcript}\n\n";
                index++;
            }

            return webVTT;
        }

        public string ToSRT()
        {
            if (this.Results == null || this.Results.Utterances == null)
            {
                throw new Exception(
                  "This method requires a transcript that was generated with the utterances feature."
                );
            }

            var srt = "";

            int index = 1;
            foreach (var utterance in this.Results.Utterances)
            {
                var start = SecondsToTimestamp(utterance.Start);
                var end = SecondsToTimestamp(utterance.End);
                srt += $"{index}\n{start} --> {end}\n - {utterance.Transcript}\n\n";
                index++;
            }

            return srt;
        }

        private string SecondsToTimestamp(decimal seconds)
        {
            return new TimeSpan((long)(seconds * 10000000)).ToString().Substring(0, (seconds % 1) == 0 ? 8 : 12);
        }
    }
}
