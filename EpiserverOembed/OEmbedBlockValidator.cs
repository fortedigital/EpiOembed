using System.Collections.Generic;
using System.Linq;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Validation;

namespace EPiServer.Oembed
{
    public class OEmbedBlockValidator : IValidate<IOEmbedBlock>
    {
        public IEnumerable<ValidationError> Validate(IOEmbedBlock instance)
        {
            if(string.IsNullOrWhiteSpace(instance.MediaUrl))
                return Enumerable.Empty<ValidationError>();
            
            var providers = ServiceLocator.Current.GetAllInstances<IOEmbedProvider>();
            if (providers.Any(p => p.CanInterpretMediaUrl(instance.MediaUrl)))
            {
                return Enumerable.Empty<ValidationError>();
            }

            return new []
            {
                new ValidationError()
                {
                    ErrorMessage = "No valid provider available for this MediaUrl",
                    PropertyName = instance.GetPropertyName(b => b.MediaUrl),
                    Severity = ValidationErrorSeverity.Error
                }
            };
        }
    }
}