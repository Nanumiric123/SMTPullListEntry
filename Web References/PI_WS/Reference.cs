﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace SMTPullListEntry.PI_WS {
    using System.Diagnostics;
    using System;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System.Web.Services;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ThirdServiceSoap", Namespace="http://tempuri.org/")]
    public partial class ThirdService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback HelloWorldOperationCompleted;
        
        private System.Threading.SendOrPostCallback LOGINSMTPULLLISTENTRYOperationCompleted;
        
        private System.Threading.SendOrPostCallback QTYPERREELPULLLISTENTRYOperationCompleted;
        
        private System.Threading.SendOrPostCallback GETDATAFROMSMTPULLLISTOperationCompleted;
        
        private System.Threading.SendOrPostCallback DELETEFROMSMTPULLLISTOperationCompleted;
        
        private System.Threading.SendOrPostCallback GETMATERIALQUANTITYPERREELOperationCompleted;
        
        private System.Threading.SendOrPostCallback SAVEPULLLISTDATAOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ThirdService() {
            this.Url = global::SMTPullListEntry.Properties.Settings.Default.SMTPullListEntry_PI_WS_ThirdService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event HelloWorldCompletedEventHandler HelloWorldCompleted;
        
        /// <remarks/>
        public event LOGINSMTPULLLISTENTRYCompletedEventHandler LOGINSMTPULLLISTENTRYCompleted;
        
        /// <remarks/>
        public event QTYPERREELPULLLISTENTRYCompletedEventHandler QTYPERREELPULLLISTENTRYCompleted;
        
        /// <remarks/>
        public event GETDATAFROMSMTPULLLISTCompletedEventHandler GETDATAFROMSMTPULLLISTCompleted;
        
        /// <remarks/>
        public event DELETEFROMSMTPULLLISTCompletedEventHandler DELETEFROMSMTPULLLISTCompleted;
        
        /// <remarks/>
        public event GETMATERIALQUANTITYPERREELCompletedEventHandler GETMATERIALQUANTITYPERREELCompleted;
        
        /// <remarks/>
        public event SAVEPULLLISTDATACompletedEventHandler SAVEPULLLISTDATACompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/HelloWorld", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void HelloWorldAsync() {
            this.HelloWorldAsync(null);
        }
        
        /// <remarks/>
        public void HelloWorldAsync(object userState) {
            if ((this.HelloWorldOperationCompleted == null)) {
                this.HelloWorldOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHelloWorldOperationCompleted);
            }
            this.InvokeAsync("HelloWorld", new object[0], this.HelloWorldOperationCompleted, userState);
        }
        
        private void OnHelloWorldOperationCompleted(object arg) {
            if ((this.HelloWorldCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HelloWorldCompleted(this, new HelloWorldCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/LOGINSMTPULLLISTENTRY", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool LOGINSMTPULLLISTENTRY(string username, string password) {
            object[] results = this.Invoke("LOGINSMTPULLLISTENTRY", new object[] {
                        username,
                        password});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void LOGINSMTPULLLISTENTRYAsync(string username, string password) {
            this.LOGINSMTPULLLISTENTRYAsync(username, password, null);
        }
        
        /// <remarks/>
        public void LOGINSMTPULLLISTENTRYAsync(string username, string password, object userState) {
            if ((this.LOGINSMTPULLLISTENTRYOperationCompleted == null)) {
                this.LOGINSMTPULLLISTENTRYOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLOGINSMTPULLLISTENTRYOperationCompleted);
            }
            this.InvokeAsync("LOGINSMTPULLLISTENTRY", new object[] {
                        username,
                        password}, this.LOGINSMTPULLLISTENTRYOperationCompleted, userState);
        }
        
        private void OnLOGINSMTPULLLISTENTRYOperationCompleted(object arg) {
            if ((this.LOGINSMTPULLLISTENTRYCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LOGINSMTPULLLISTENTRYCompleted(this, new LOGINSMTPULLLISTENTRYCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/QTYPERREELPULLLISTENTRY", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int QTYPERREELPULLLISTENTRY(string material) {
            object[] results = this.Invoke("QTYPERREELPULLLISTENTRY", new object[] {
                        material});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void QTYPERREELPULLLISTENTRYAsync(string material) {
            this.QTYPERREELPULLLISTENTRYAsync(material, null);
        }
        
        /// <remarks/>
        public void QTYPERREELPULLLISTENTRYAsync(string material, object userState) {
            if ((this.QTYPERREELPULLLISTENTRYOperationCompleted == null)) {
                this.QTYPERREELPULLLISTENTRYOperationCompleted = new System.Threading.SendOrPostCallback(this.OnQTYPERREELPULLLISTENTRYOperationCompleted);
            }
            this.InvokeAsync("QTYPERREELPULLLISTENTRY", new object[] {
                        material}, this.QTYPERREELPULLLISTENTRYOperationCompleted, userState);
        }
        
        private void OnQTYPERREELPULLLISTENTRYOperationCompleted(object arg) {
            if ((this.QTYPERREELPULLLISTENTRYCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.QTYPERREELPULLLISTENTRYCompleted(this, new QTYPERREELPULLLISTENTRYCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GETDATAFROMSMTPULLLIST", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GETDATAFROMSMTPULLLIST(string bnum) {
            object[] results = this.Invoke("GETDATAFROMSMTPULLLIST", new object[] {
                        bnum});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void GETDATAFROMSMTPULLLISTAsync(string bnum) {
            this.GETDATAFROMSMTPULLLISTAsync(bnum, null);
        }
        
        /// <remarks/>
        public void GETDATAFROMSMTPULLLISTAsync(string bnum, object userState) {
            if ((this.GETDATAFROMSMTPULLLISTOperationCompleted == null)) {
                this.GETDATAFROMSMTPULLLISTOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGETDATAFROMSMTPULLLISTOperationCompleted);
            }
            this.InvokeAsync("GETDATAFROMSMTPULLLIST", new object[] {
                        bnum}, this.GETDATAFROMSMTPULLLISTOperationCompleted, userState);
        }
        
        private void OnGETDATAFROMSMTPULLLISTOperationCompleted(object arg) {
            if ((this.GETDATAFROMSMTPULLLISTCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GETDATAFROMSMTPULLLISTCompleted(this, new GETDATAFROMSMTPULLLISTCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/DELETEFROMSMTPULLLIST", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void DELETEFROMSMTPULLLIST(string material, string bnum) {
            this.Invoke("DELETEFROMSMTPULLLIST", new object[] {
                        material,
                        bnum});
        }
        
        /// <remarks/>
        public void DELETEFROMSMTPULLLISTAsync(string material, string bnum) {
            this.DELETEFROMSMTPULLLISTAsync(material, bnum, null);
        }
        
        /// <remarks/>
        public void DELETEFROMSMTPULLLISTAsync(string material, string bnum, object userState) {
            if ((this.DELETEFROMSMTPULLLISTOperationCompleted == null)) {
                this.DELETEFROMSMTPULLLISTOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDELETEFROMSMTPULLLISTOperationCompleted);
            }
            this.InvokeAsync("DELETEFROMSMTPULLLIST", new object[] {
                        material,
                        bnum}, this.DELETEFROMSMTPULLLISTOperationCompleted, userState);
        }
        
        private void OnDELETEFROMSMTPULLLISTOperationCompleted(object arg) {
            if ((this.DELETEFROMSMTPULLLISTCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DELETEFROMSMTPULLLISTCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GETMATERIALQUANTITYPERREEL", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int GETMATERIALQUANTITYPERREEL(string material) {
            object[] results = this.Invoke("GETMATERIALQUANTITYPERREEL", new object[] {
                        material});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void GETMATERIALQUANTITYPERREELAsync(string material) {
            this.GETMATERIALQUANTITYPERREELAsync(material, null);
        }
        
        /// <remarks/>
        public void GETMATERIALQUANTITYPERREELAsync(string material, object userState) {
            if ((this.GETMATERIALQUANTITYPERREELOperationCompleted == null)) {
                this.GETMATERIALQUANTITYPERREELOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGETMATERIALQUANTITYPERREELOperationCompleted);
            }
            this.InvokeAsync("GETMATERIALQUANTITYPERREEL", new object[] {
                        material}, this.GETMATERIALQUANTITYPERREELOperationCompleted, userState);
        }
        
        private void OnGETMATERIALQUANTITYPERREELOperationCompleted(object arg) {
            if ((this.GETMATERIALQUANTITYPERREELCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GETMATERIALQUANTITYPERREELCompleted(this, new GETMATERIALQUANTITYPERREELCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SAVEPULLLISTDATA", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void SAVEPULLLISTDATA(string material, string s_reqQty, int reelQty, string location, string badgeNumber) {
            this.Invoke("SAVEPULLLISTDATA", new object[] {
                        material,
                        s_reqQty,
                        reelQty,
                        location,
                        badgeNumber});
        }
        
        /// <remarks/>
        public void SAVEPULLLISTDATAAsync(string material, string s_reqQty, int reelQty, string location, string badgeNumber) {
            this.SAVEPULLLISTDATAAsync(material, s_reqQty, reelQty, location, badgeNumber, null);
        }
        
        /// <remarks/>
        public void SAVEPULLLISTDATAAsync(string material, string s_reqQty, int reelQty, string location, string badgeNumber, object userState) {
            if ((this.SAVEPULLLISTDATAOperationCompleted == null)) {
                this.SAVEPULLLISTDATAOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSAVEPULLLISTDATAOperationCompleted);
            }
            this.InvokeAsync("SAVEPULLLISTDATA", new object[] {
                        material,
                        s_reqQty,
                        reelQty,
                        location,
                        badgeNumber}, this.SAVEPULLLISTDATAOperationCompleted, userState);
        }
        
        private void OnSAVEPULLLISTDATAOperationCompleted(object arg) {
            if ((this.SAVEPULLLISTDATACompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SAVEPULLLISTDATACompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    public delegate void HelloWorldCompletedEventHandler(object sender, HelloWorldCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HelloWorldCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HelloWorldCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    public delegate void LOGINSMTPULLLISTENTRYCompletedEventHandler(object sender, LOGINSMTPULLLISTENTRYCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LOGINSMTPULLLISTENTRYCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LOGINSMTPULLLISTENTRYCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    public delegate void QTYPERREELPULLLISTENTRYCompletedEventHandler(object sender, QTYPERREELPULLLISTENTRYCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class QTYPERREELPULLLISTENTRYCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal QTYPERREELPULLLISTENTRYCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    public delegate void GETDATAFROMSMTPULLLISTCompletedEventHandler(object sender, GETDATAFROMSMTPULLLISTCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GETDATAFROMSMTPULLLISTCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GETDATAFROMSMTPULLLISTCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    public delegate void DELETEFROMSMTPULLLISTCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    public delegate void GETMATERIALQUANTITYPERREELCompletedEventHandler(object sender, GETMATERIALQUANTITYPERREELCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GETMATERIALQUANTITYPERREELCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GETMATERIALQUANTITYPERREELCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9037.0")]
    public delegate void SAVEPULLLISTDATACompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591