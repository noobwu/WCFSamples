using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace Artech.Serialization
{
    public class ContractSurrogate : IDataContractSurrogate
    {
        public Type GetDataContractType(Type type)
        {
            if (type == typeof(Contact))
            {
                return typeof(Customer);
            }
            return type;
        }
        public object GetDeserializedObject(object obj, Type targetType)
        {
            Customer customer = obj as Customer;
            if (customer == null)
            {
                return obj;
            }
            return new Contact
            {
                FullName = customer.FirstName + " " + customer.LastName,
                Sex = customer.Gender
            };
        }
        public object GetObjectToSerialize(object obj, Type targetType)
        {
            Contact contact = obj as Contact;
            if (contact == null)
            {
                return obj;
            }
            return new Customer
            {
                FirstName = contact.FullName.Split(" ".ToCharArray())[0],
                LastName = contact.FullName.Split(" ".ToCharArray())[1],
                Gender = contact.Sex
            };
        }

        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes) { }
        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            return null;
        }
        public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            return null;
        }
        public Type GetReferencedTypeOnImport(string typeName,
            string typeNamespace, object customData)
        {
            return null;
        }
        public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
        {
            return typeDeclaration;
        }
    }
}
