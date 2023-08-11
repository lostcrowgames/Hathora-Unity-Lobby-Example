/*
 * Hathora Cloud API
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 0.0.1
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using OpenAPIDateConverter = Hathora.Cloud.Sdk.Client.OpenAPIDateConverter;

namespace Hathora.Cloud.Sdk.Model
{
    /// <summary>
    /// DiscoveryResponseInner
    /// </summary>
    [DataContract(Name = "DiscoveryResponse_inner")]
    public partial class DiscoveryResponseInner : IEquatable<DiscoveryResponseInner>
    {

        /// <summary>
        /// Gets or Sets Region
        /// </summary>
        [DataMember(Name = "region", IsRequired = true, EmitDefaultValue = true)]
        public Region Region { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscoveryResponseInner" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected DiscoveryResponseInner()
        {
            this.AdditionalProperties = new Dictionary<string, object>();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscoveryResponseInner" /> class.
        /// </summary>
        /// <param name="port">port (required).</param>
        /// <param name="host">host (required).</param>
        /// <param name="region">region (required).</param>
        public DiscoveryResponseInner(double port = default(double), string host = default(string), Region region = default(Region))
        {
            this.Port = port;
            // to ensure "host" is required (not null)
            if (host == null)
            {
                throw new ArgumentNullException("host is a required property for DiscoveryResponseInner and cannot be null");
            }
            this.Host = host;
            this.Region = region;
            this.AdditionalProperties = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or Sets Port
        /// </summary>
        [DataMember(Name = "port", IsRequired = true, EmitDefaultValue = true)]
        public double Port { get; set; }

        /// <summary>
        /// Gets or Sets Host
        /// </summary>
        [DataMember(Name = "host", IsRequired = true, EmitDefaultValue = true)]
        public string Host { get; set; }

        /// <summary>
        /// Gets or Sets additional properties
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class DiscoveryResponseInner {\n");
            sb.Append("  Port: ").Append(Port).Append("\n");
            sb.Append("  Host: ").Append(Host).Append("\n");
            sb.Append("  Region: ").Append(Region).Append("\n");
            sb.Append("  AdditionalProperties: ").Append(AdditionalProperties).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as DiscoveryResponseInner);
        }

        /// <summary>
        /// Returns true if DiscoveryResponseInner instances are equal
        /// </summary>
        /// <param name="input">Instance of DiscoveryResponseInner to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DiscoveryResponseInner input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Port == input.Port ||
                    this.Port.Equals(input.Port)
                ) && 
                (
                    this.Host == input.Host ||
                    (this.Host != null &&
                    this.Host.Equals(input.Host))
                ) && 
                (
                    this.Region == input.Region ||
                    this.Region.Equals(input.Region)
                )
                && (this.AdditionalProperties.Count == input.AdditionalProperties.Count && !this.AdditionalProperties.Except(input.AdditionalProperties).Any());
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                hashCode = (hashCode * 59) + this.Port.GetHashCode();
                if (this.Host != null)
                {
                    hashCode = (hashCode * 59) + this.Host.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Region.GetHashCode();
                if (this.AdditionalProperties != null)
                {
                    hashCode = (hashCode * 59) + this.AdditionalProperties.GetHashCode();
                }
                return hashCode;
            }
        }

    }

}
