﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RC.FacElecCol.ServicioWindows.RentingFacElecCol {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RentingFacElecCol.IRentingFeCoService")]
    public interface IRentingFeCoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRentingFeCoService/GenerarXml", ReplyAction="http://tempuri.org/IRentingFeCoService/GenerarXmlResponse")]
        bool GenerarXml();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRentingFeCoService/GenerarXml", ReplyAction="http://tempuri.org/IRentingFeCoService/GenerarXmlResponse")]
        System.Threading.Tasks.Task<bool> GenerarXmlAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRentingFeCoServiceChannel : RC.FacElecCol.ServicioWindows.RentingFacElecCol.IRentingFeCoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RentingFeCoServiceClient : System.ServiceModel.ClientBase<RC.FacElecCol.ServicioWindows.RentingFacElecCol.IRentingFeCoService>, RC.FacElecCol.ServicioWindows.RentingFacElecCol.IRentingFeCoService {
        
        public RentingFeCoServiceClient() {
        }
        
        public RentingFeCoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RentingFeCoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RentingFeCoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RentingFeCoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool GenerarXml() {
            return base.Channel.GenerarXml();
        }
        
        public System.Threading.Tasks.Task<bool> GenerarXmlAsync() {
            return base.Channel.GenerarXmlAsync();
        }
    }
}
