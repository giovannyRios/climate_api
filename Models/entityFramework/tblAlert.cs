//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace climate_API.Models.entityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblAlert
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAlert()
        {
            this.tblWeatherForecast = new HashSet<tblWeatherForecast>();
        }
    
        public int ID { get; set; }
        public string NameAlert { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblWeatherForecast> tblWeatherForecast { get; set; }
    }
}
