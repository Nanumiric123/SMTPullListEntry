﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SMTPullListEntry.GETPARTLOC {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GETPARTLOC.Local_Ws_secondSoap")]
    public interface Local_Ws_secondSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string HelloWorld();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        System.Threading.Tasks.Task<string> HelloWorldAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GET_PART_NUM_FROM_ORDER", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GET_PART_NUM_FROM_ORDER(string PO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GET_PART_NUM_FROM_ORDER", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GET_PART_NUM_FROM_ORDERAsync(string PO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GET_DATA_FROM_BARC_INN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable GET_DATA_FROM_BARC_INN(string stor_loc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GET_DATA_FROM_BARC_INN", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> GET_DATA_FROM_BARC_INNAsync(string stor_loc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/RECEIVING_TOCK_2001", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable RECEIVING_TOCK_2001();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/RECEIVING_TOCK_2001", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> RECEIVING_TOCK_2001Async();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/check_badge_valid", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool check_badge_valid(string badge_no);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/check_badge_valid", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> check_badge_validAsync(string badge_no);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/cycle_count_insert_data_to_table", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string cycle_count_insert_data_to_table(System.Data.DataTable data_from_bin, System.Data.DataTable data_from_sap, string stge_bin, string STOR_LOC, string badge_num);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/cycle_count_insert_data_to_table", ReplyAction="*")]
        System.Threading.Tasks.Task<string> cycle_count_insert_data_to_tableAsync(System.Data.DataTable data_from_bin, System.Data.DataTable data_from_sap, string stge_bin, string STOR_LOC, string badge_num);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MPQsubmitToSAPT32", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string MPQsubmitToSAPT32(string binNo, string kanbanMaterial, string location, string badgeNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MPQsubmitToSAPT32", ReplyAction="*")]
        System.Threading.Tasks.Task<string> MPQsubmitToSAPT32Async(string binNo, string kanbanMaterial, string location, string badgeNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MPPsubmitToSAPT32", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string MPPsubmitToSAPT32(string binNo, string kanbanMaterial, string location, string badgeNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MPPsubmitToSAPT32", ReplyAction="*")]
        System.Threading.Tasks.Task<string> MPPsubmitToSAPT32Async(string binNo, string kanbanMaterial, string location, string badgeNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GET_MATERIAL_FROM_001", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool GET_MATERIAL_FROM_001(string material);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GET_MATERIAL_FROM_001", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> GET_MATERIAL_FROM_001Async(string material);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GETMaterialLocMFRPN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GETMaterialLocMFRPN(string material);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GETMaterialLocMFRPN", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GETMaterialLocMFRPNAsync(string material);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GETMaterialLocMFRPNBoth", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable GETMaterialLocMFRPNBoth(string material);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GETMaterialLocMFRPNBoth", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> GETMaterialLocMFRPNBothAsync(string material);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetMaterialFromWH", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable GetMaterialFromWH(string material);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetMaterialFromWH", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetMaterialFromWHAsync(string material);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GET_BIN_FROM_006", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable GET_BIN_FROM_006(string material);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GET_BIN_FROM_006", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> GET_BIN_FROM_006Async(string material);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface Local_Ws_secondSoapChannel : SMTPullListEntry.GETPARTLOC.Local_Ws_secondSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Local_Ws_secondSoapClient : System.ServiceModel.ClientBase<SMTPullListEntry.GETPARTLOC.Local_Ws_secondSoap>, SMTPullListEntry.GETPARTLOC.Local_Ws_secondSoap {
        
        public Local_Ws_secondSoapClient() {
        }
        
        public Local_Ws_secondSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Local_Ws_secondSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Local_Ws_secondSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Local_Ws_secondSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string HelloWorld() {
            return base.Channel.HelloWorld();
        }
        
        public System.Threading.Tasks.Task<string> HelloWorldAsync() {
            return base.Channel.HelloWorldAsync();
        }
        
        public string GET_PART_NUM_FROM_ORDER(string PO) {
            return base.Channel.GET_PART_NUM_FROM_ORDER(PO);
        }
        
        public System.Threading.Tasks.Task<string> GET_PART_NUM_FROM_ORDERAsync(string PO) {
            return base.Channel.GET_PART_NUM_FROM_ORDERAsync(PO);
        }
        
        public System.Data.DataTable GET_DATA_FROM_BARC_INN(string stor_loc) {
            return base.Channel.GET_DATA_FROM_BARC_INN(stor_loc);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GET_DATA_FROM_BARC_INNAsync(string stor_loc) {
            return base.Channel.GET_DATA_FROM_BARC_INNAsync(stor_loc);
        }
        
        public System.Data.DataTable RECEIVING_TOCK_2001() {
            return base.Channel.RECEIVING_TOCK_2001();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> RECEIVING_TOCK_2001Async() {
            return base.Channel.RECEIVING_TOCK_2001Async();
        }
        
        public bool check_badge_valid(string badge_no) {
            return base.Channel.check_badge_valid(badge_no);
        }
        
        public System.Threading.Tasks.Task<bool> check_badge_validAsync(string badge_no) {
            return base.Channel.check_badge_validAsync(badge_no);
        }
        
        public string cycle_count_insert_data_to_table(System.Data.DataTable data_from_bin, System.Data.DataTable data_from_sap, string stge_bin, string STOR_LOC, string badge_num) {
            return base.Channel.cycle_count_insert_data_to_table(data_from_bin, data_from_sap, stge_bin, STOR_LOC, badge_num);
        }
        
        public System.Threading.Tasks.Task<string> cycle_count_insert_data_to_tableAsync(System.Data.DataTable data_from_bin, System.Data.DataTable data_from_sap, string stge_bin, string STOR_LOC, string badge_num) {
            return base.Channel.cycle_count_insert_data_to_tableAsync(data_from_bin, data_from_sap, stge_bin, STOR_LOC, badge_num);
        }
        
        public string MPQsubmitToSAPT32(string binNo, string kanbanMaterial, string location, string badgeNum) {
            return base.Channel.MPQsubmitToSAPT32(binNo, kanbanMaterial, location, badgeNum);
        }
        
        public System.Threading.Tasks.Task<string> MPQsubmitToSAPT32Async(string binNo, string kanbanMaterial, string location, string badgeNum) {
            return base.Channel.MPQsubmitToSAPT32Async(binNo, kanbanMaterial, location, badgeNum);
        }
        
        public string MPPsubmitToSAPT32(string binNo, string kanbanMaterial, string location, string badgeNum) {
            return base.Channel.MPPsubmitToSAPT32(binNo, kanbanMaterial, location, badgeNum);
        }
        
        public System.Threading.Tasks.Task<string> MPPsubmitToSAPT32Async(string binNo, string kanbanMaterial, string location, string badgeNum) {
            return base.Channel.MPPsubmitToSAPT32Async(binNo, kanbanMaterial, location, badgeNum);
        }
        
        public bool GET_MATERIAL_FROM_001(string material) {
            return base.Channel.GET_MATERIAL_FROM_001(material);
        }
        
        public System.Threading.Tasks.Task<bool> GET_MATERIAL_FROM_001Async(string material) {
            return base.Channel.GET_MATERIAL_FROM_001Async(material);
        }
        
        public string GETMaterialLocMFRPN(string material) {
            return base.Channel.GETMaterialLocMFRPN(material);
        }
        
        public System.Threading.Tasks.Task<string> GETMaterialLocMFRPNAsync(string material) {
            return base.Channel.GETMaterialLocMFRPNAsync(material);
        }
        
        public System.Data.DataTable GETMaterialLocMFRPNBoth(string material) {
            return base.Channel.GETMaterialLocMFRPNBoth(material);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GETMaterialLocMFRPNBothAsync(string material) {
            return base.Channel.GETMaterialLocMFRPNBothAsync(material);
        }
        
        public System.Data.DataTable GetMaterialFromWH(string material) {
            return base.Channel.GetMaterialFromWH(material);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetMaterialFromWHAsync(string material) {
            return base.Channel.GetMaterialFromWHAsync(material);
        }
        
        public System.Data.DataTable GET_BIN_FROM_006(string material) {
            return base.Channel.GET_BIN_FROM_006(material);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GET_BIN_FROM_006Async(string material) {
            return base.Channel.GET_BIN_FROM_006Async(material);
        }
    }
}
