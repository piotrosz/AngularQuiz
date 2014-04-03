using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using AngularQuiz.Core.Model;

namespace AngularQuiz.Web.Infrastructure
{
    public class UserDataOnlyContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (Attribute.IsDefined(member, typeof(SecretAttribute)))
            {
                property.ShouldSerialize = instance => { return false; };
            }

            return property;
        }
    }
}