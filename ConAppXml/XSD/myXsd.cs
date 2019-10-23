namespace Xsd2 
{
    using System;
    using System.Collections.Generic;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/PurchaseOrderSchema.xsd")]
    [System.Xml.Serialization.XmlRootAttribute("PurchaseOrder", Namespace="http://tempuri.org/PurchaseOrderSchema.xsd", IsNullable=false)]
    public partial class PurchaseOrderType {
        
        private List<USAddress> shipToField;
        
        private USAddress billToField;
        
        private System.DateTime orderDateField;
        
        private bool orderDateFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ShipTo")]
        public List<USAddress> ShipTo {
            get {
                return this.shipToField;
            }
            set {
                this.shipToField = value;
            }
        }
        
        /// <remarks/>
        public USAddress BillTo {
            get {
                return this.billToField;
            }
            set {
                this.billToField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="date", AttributeName="OrderDate")]
        public System.DateTime _OrderDate {
            get {
                return this.orderDateField;
            }
            set {
                this.orderDateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool _OrderDateSpecified {
            get {
                return this.orderDateFieldSpecified;
            }
            set {
                this.orderDateFieldSpecified = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public Nullable<System.DateTime> OrderDate {
            get {
                if (orderDateFieldSpecified) {
                    return orderDateField;
                }
                else {
                    return null;
                }
            }
            set {
                if (value != null) {
                    orderDateFieldSpecified = true;
                    orderDateField = value.Value;
                }
                else {
                    orderDateFieldSpecified = false;
                }
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/PurchaseOrderSchema.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/PurchaseOrderSchema.xsd", IsNullable=true)]
    public partial class USAddress {
        private const string V = "country";
        private string nameField;
        
        private string streetField;
        
        private string cityField;
        
        private string stateField;
        
        private string zipField;
        
        private string countryField;
        
        public USAddress() {
            this.countryField = "US";
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("name")]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("street")]
        public string Street {
            get {
                return this.streetField;
            }
            set {
                this.streetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("city")]
        public string City {
            get {
                return this.cityField;
            }
            set {
                this.cityField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("state")]
        public string State {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
        public string Zip {
            get {
                return this.zipField;
            }
            set {
                this.zipField = value;
            }
        }
        
        /// <remarks/>
       
        public string Country {
            get {
                return this.countryField;
            }
            set {
                this.countryField = value;
            }
        }
    }
}
