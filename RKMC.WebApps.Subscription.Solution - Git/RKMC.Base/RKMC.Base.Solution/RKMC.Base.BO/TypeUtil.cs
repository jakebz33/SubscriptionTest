using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Text;

namespace RKMC.Base
{
    public class TypeUtil
    {
        //notes:    allows method to be called dynamically
        public static Object InvokeStringMethod(string assemblyName, string namespaceName, string typeName, string methodName)
        {
            Type calledType = Type.GetType(namespaceName + "." + typeName + "," + assemblyName);

            return (Object)calledType.InvokeMember(methodName, BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, null);
        }
        public static Object InvokeStringMethod(string AssemblyName, string NamespaceName, string TypeName, string MethodName, NameValueCollection Parameters)
        {
            Type calledType = Type.GetType(NamespaceName + "." + TypeName + "," + AssemblyName);

            return (Object)calledType.InvokeMember(MethodName, BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, new Object[] { Parameters });
        }
    }
}