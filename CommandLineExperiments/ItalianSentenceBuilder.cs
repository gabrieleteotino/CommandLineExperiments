using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace CommandLineExperiments
{
    internal class ItalianSentenceBuilder : SentenceBuilder
    {
        public override Func<string> RequiredWord
        {
            get { return () => "Richiesto."; }
        }

        public override Func<string> ErrorsHeadingText
        {
            get { return () => "ERRORE(I):"; }
        }

        public override Func<string> UsageHeadingText
        {
            get { return () => "UTILIZZO:"; }
        }

        public override Func<bool, string> HelpCommandText
        {
            get
            {
                return isOption => isOption
                    ? "Mostra questa schermata di aiuto."
                    : "Mostra più informazioni su uno specifico comando.";
            }
        }

        public override Func<bool, string> VersionCommandText
        {
            get { return _ => "Mostra informazioni sulla versione."; }
        }

        public override Func<Error, string> FormatError
        {
            get
            {
                return error =>
                {
                    switch (error.Tag)
                    {
                        case ErrorType.BadFormatTokenError:
                            return $"Token '{((BadFormatTokenError)error).Token}' is not recognized.";
                        case ErrorType.MissingValueOptionError:
                            return $"Option '{((MissingValueOptionError)error).NameInfo.NameText}' has no value.";
                        case ErrorType.UnknownOptionError:
                            return $"Option '{((UnknownOptionError)error).Token}' is unknown.";
                        case ErrorType.MissingRequiredOptionError:
                            var errMisssing = ((MissingRequiredOptionError)error);
                            return errMisssing.NameInfo.Equals(NameInfo.EmptyName)
                                       ? "A required value not bound to option name is missing."
                                       : $"Required option '{errMisssing.NameInfo.NameText}' is missing.";
                        case ErrorType.BadFormatConversionError:
                            var badFormat = ((BadFormatConversionError)error);
                            return badFormat.NameInfo.Equals(NameInfo.EmptyName)
                                       ? "A value not bound to option name is defined with a bad format."
                                       : $"Option '{badFormat.NameInfo.NameText}' is defined with a bad format.";
                        case ErrorType.SequenceOutOfRangeError:
                            var seqOutRange = ((SequenceOutOfRangeError)error);
                            return seqOutRange.NameInfo.Equals(NameInfo.EmptyName)
                                       ? "A sequence value not bound to option name is defined with few items than required."
                                       : $"A sequence option '{seqOutRange.NameInfo.NameText}' is defined with fewer or more items than required.";
                        case ErrorType.BadVerbSelectedError:
                            return $"Verb '{((BadVerbSelectedError)error).Token}' is not recognized.";
                        case ErrorType.NoVerbSelectedError:
                            return "No verb selected.";
                        case ErrorType.RepeatedOptionError:
                            return $"Option '{((RepeatedOptionError)error).NameInfo.NameText}' is defined multiple times.";
                    }
                    throw new InvalidOperationException();
                };
            }
        }

        public override Func<IEnumerable<MutuallyExclusiveSetError>, string> FormatMutuallyExclusiveSetErrors
        {
            get
            {
                return errors =>
                {
                    var bySet = from e in errors
                                group e by e.SetName into g
                                select new { SetName = g.Key, Errors = g.ToList() };

                    var msgs = bySet.Select(
                        set =>
                        {
                            var names = string.Join(
                                string.Empty,
                                (from e in set.Errors select $"'{e.NameInfo.NameText}', ").ToArray());
                            var namesCount = set.Errors.Count;

                            var incompat = string.Join(
                                string.Empty,
                                from x in
                                     (from s in bySet where !s.SetName.Equals(set.SetName) from e in s.Errors select e)
                                    .Distinct()
                                 select $"'{x.NameInfo.NameText}', ");

                            return
                                new StringBuilder("Opzion")
                                        .Append((namesCount > 1) ? "i" : "e")
                                        .Append(": ")
                                        .Append(names, 0, names.Length - 2)
                                        .Append(' ')
                                        .Append((namesCount > 1) ? "sono incompatibili" : "è incompatibile")
                                        .Append(" con: ")
                                        .Append(incompat, 0, incompat.Length - 2)
                                        .Append('.')
                                    .ToString();
                        }).ToArray();
                    return string.Join(Environment.NewLine, msgs);
                };
            }
        }
    }
}
