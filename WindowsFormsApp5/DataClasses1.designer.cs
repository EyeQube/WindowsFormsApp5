﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp5
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="AdressBook")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertBizContact(BizContact instance);
    partial void UpdateBizContact(BizContact instance);
    partial void DeleteBizContact(BizContact instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::WindowsFormsApp5.Properties.Settings.Default.AdressBookConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<BizContact> BizContacts
		{
			get
			{
				return this.GetTable<BizContact>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.BizContacts")]
	public partial class BizContact : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private System.DateTime _Beslutsdatum;
		
		private string _Personnummer;
		
		private string _Förnamn;
		
		private string _Efternamn;
		
		private string _Insatskategori;
		
		private string _Beslut;
		
		private string _Beslutsfattare;
		
		private string _Organisation;
		
		private string _Orsak;
		
		private string _Anteckningar;
		
		private System.Data.Linq.Binary _Foto;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnBeslutsdatumChanging(System.DateTime value);
    partial void OnBeslutsdatumChanged();
    partial void OnPersonnummerChanging(string value);
    partial void OnPersonnummerChanged();
    partial void OnFörnamnChanging(string value);
    partial void OnFörnamnChanged();
    partial void OnEfternamnChanging(string value);
    partial void OnEfternamnChanged();
    partial void OnInsatskategoriChanging(string value);
    partial void OnInsatskategoriChanged();
    partial void OnBeslutChanging(string value);
    partial void OnBeslutChanged();
    partial void OnBeslutsfattareChanging(string value);
    partial void OnBeslutsfattareChanged();
    partial void OnOrganisationChanging(string value);
    partial void OnOrganisationChanged();
    partial void OnOrsakChanging(string value);
    partial void OnOrsakChanged();
    partial void OnAnteckningarChanging(string value);
    partial void OnAnteckningarChanged();
    partial void OnFotoChanging(System.Data.Linq.Binary value);
    partial void OnFotoChanged();
    #endregion
		
		/*public BizContact()
		{
			OnCreated();
		}*/
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Beslutsdatum", DbType="DateTime NOT NULL")]
		public System.DateTime Beslutsdatum
		{
			get
			{
				return this._Beslutsdatum;
			}
			set
			{
				if ((this._Beslutsdatum != value))
				{
					this.OnBeslutsdatumChanging(value);
					this.SendPropertyChanging();
					this._Beslutsdatum = value;
					this.SendPropertyChanged("Beslutsdatum");
					this.OnBeslutsdatumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Personnummer", DbType="VarChar(13)")]
		public string Personnummer
		{
			get
			{
				return this._Personnummer;
			}
			set
			{
				if ((this._Personnummer != value))
				{
					this.OnPersonnummerChanging(value);
					this.SendPropertyChanging();
					this._Personnummer = value;
					this.SendPropertyChanged("Personnummer");
					this.OnPersonnummerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Förnamn", DbType="NVarChar(100)")]
		public string Förnamn
		{
			get
			{
				return this._Förnamn;
			}
			set
			{
				if ((this._Förnamn != value))
				{
					this.OnFörnamnChanging(value);
					this.SendPropertyChanging();
					this._Förnamn = value;
					this.SendPropertyChanged("Förnamn");
					this.OnFörnamnChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Efternamn", DbType="NVarChar(100)")]
		public string Efternamn
		{
			get
			{
				return this._Efternamn;
			}
			set
			{
				if ((this._Efternamn != value))
				{
					this.OnEfternamnChanging(value);
					this.SendPropertyChanging();
					this._Efternamn = value;
					this.SendPropertyChanged("Efternamn");
					this.OnEfternamnChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Insatskategori", DbType="NVarChar(100)")]
		public string Insatskategori
		{
			get
			{
				return this._Insatskategori;
			}
			set
			{
				if ((this._Insatskategori != value))
				{
					this.OnInsatskategoriChanging(value);
					this.SendPropertyChanging();
					this._Insatskategori = value;
					this.SendPropertyChanged("Insatskategori");
					this.OnInsatskategoriChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Beslut", DbType="NVarChar(100)")]
		public string Beslut
		{
			get
			{
				return this._Beslut;
			}
			set
			{
				if ((this._Beslut != value))
				{
					this.OnBeslutChanging(value);
					this.SendPropertyChanging();
					this._Beslut = value;
					this.SendPropertyChanged("Beslut");
					this.OnBeslutChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Beslutsfattare", DbType="NVarChar(100)")]
		public string Beslutsfattare
		{
			get
			{
				return this._Beslutsfattare;
			}
			set
			{
				if ((this._Beslutsfattare != value))
				{
					this.OnBeslutsfattareChanging(value);
					this.SendPropertyChanging();
					this._Beslutsfattare = value;
					this.SendPropertyChanged("Beslutsfattare");
					this.OnBeslutsfattareChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Organisation", DbType="NVarChar(100)")]
		public string Organisation
		{
			get
			{
				return this._Organisation;
			}
			set
			{
				if ((this._Organisation != value))
				{
					this.OnOrganisationChanging(value);
					this.SendPropertyChanging();
					this._Organisation = value;
					this.SendPropertyChanged("Organisation");
					this.OnOrganisationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Orsak", DbType="NVarChar(100)")]
		public string Orsak
		{
			get
			{
				return this._Orsak;
			}
			set
			{
				if ((this._Orsak != value))
				{
					this.OnOrsakChanging(value);
					this.SendPropertyChanging();
					this._Orsak = value;
					this.SendPropertyChanged("Orsak");
					this.OnOrsakChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Anteckningar", DbType="NVarChar(1000)")]
		public string Anteckningar
		{
			get
			{
				return this._Anteckningar;
			}
			set
			{
				if ((this._Anteckningar != value))
				{
					this.OnAnteckningarChanging(value);
					this.SendPropertyChanging();
					this._Anteckningar = value;
					this.SendPropertyChanged("Anteckningar");
					this.OnAnteckningarChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Foto", DbType="VarBinary(MAX)", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Foto
		{
			get
			{
				return this._Foto;
			}
			set
			{
				if ((this._Foto != value))
				{
					this.OnFotoChanging(value);
					this.SendPropertyChanging();
					this._Foto = value;
					this.SendPropertyChanged("Foto");
					this.OnFotoChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
