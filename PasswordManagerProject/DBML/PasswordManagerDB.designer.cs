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

namespace PasswordManagerProject.DBML
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="pass123db")]
	public partial class PasswordManagerDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertUserInfo(UserInfo instance);
    partial void UpdateUserInfo(UserInfo instance);
    partial void DeleteUserInfo(UserInfo instance);
    partial void InsertPasswordInfo(PasswordInfo instance);
    partial void UpdatePasswordInfo(PasswordInfo instance);
    partial void DeletePasswordInfo(PasswordInfo instance);
    #endregion
		
		public PasswordManagerDBDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["pass123dbConnectionString2"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public PasswordManagerDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PasswordManagerDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PasswordManagerDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PasswordManagerDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<UserInfo> UserInfos
		{
			get
			{
				return this.GetTable<UserInfo>();
			}
		}
		
		public System.Data.Linq.Table<KeyInfo> KeyInfos
		{
			get
			{
				return this.GetTable<KeyInfo>();
			}
		}
		
		public System.Data.Linq.Table<PasswordInfo> PasswordInfos
		{
			get
			{
				return this.GetTable<PasswordInfo>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserInfo")]
	public partial class UserInfo : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserId;
		
		private string _Username;
		
		private string _MasterPassword;
		
		private string _FullName;
		
		private System.DateTime _DateOfBirth;
		
		private string _EmailAddress;
		
		private System.DateTime _DateCreated;
		
		private EntityRef<UserInfo> _UserInfo2;
		
		private EntityRef<UserInfo> _UserInfo1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnMasterPasswordChanging(string value);
    partial void OnMasterPasswordChanged();
    partial void OnFullNameChanging(string value);
    partial void OnFullNameChanged();
    partial void OnDateOfBirthChanging(System.DateTime value);
    partial void OnDateOfBirthChanged();
    partial void OnEmailAddressChanging(string value);
    partial void OnEmailAddressChanged();
    partial void OnDateCreatedChanging(System.DateTime value);
    partial void OnDateCreatedChanged();
    #endregion
		
		public UserInfo()
		{
			this._UserInfo2 = default(EntityRef<UserInfo>);
			this._UserInfo1 = default(EntityRef<UserInfo>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					if (this._UserInfo1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MasterPassword", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string MasterPassword
		{
			get
			{
				return this._MasterPassword;
			}
			set
			{
				if ((this._MasterPassword != value))
				{
					this.OnMasterPasswordChanging(value);
					this.SendPropertyChanging();
					this._MasterPassword = value;
					this.SendPropertyChanged("MasterPassword");
					this.OnMasterPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FullName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string FullName
		{
			get
			{
				return this._FullName;
			}
			set
			{
				if ((this._FullName != value))
				{
					this.OnFullNameChanging(value);
					this.SendPropertyChanging();
					this._FullName = value;
					this.SendPropertyChanged("FullName");
					this.OnFullNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateOfBirth", DbType="DateTime NOT NULL")]
		public System.DateTime DateOfBirth
		{
			get
			{
				return this._DateOfBirth;
			}
			set
			{
				if ((this._DateOfBirth != value))
				{
					this.OnDateOfBirthChanging(value);
					this.SendPropertyChanging();
					this._DateOfBirth = value;
					this.SendPropertyChanged("DateOfBirth");
					this.OnDateOfBirthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmailAddress", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string EmailAddress
		{
			get
			{
				return this._EmailAddress;
			}
			set
			{
				if ((this._EmailAddress != value))
				{
					this.OnEmailAddressChanging(value);
					this.SendPropertyChanging();
					this._EmailAddress = value;
					this.SendPropertyChanged("EmailAddress");
					this.OnEmailAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateCreated", DbType="DateTime NOT NULL")]
		public System.DateTime DateCreated
		{
			get
			{
				return this._DateCreated;
			}
			set
			{
				if ((this._DateCreated != value))
				{
					this.OnDateCreatedChanging(value);
					this.SendPropertyChanging();
					this._DateCreated = value;
					this.SendPropertyChanged("DateCreated");
					this.OnDateCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="UserInfo_UserInfo", Storage="_UserInfo2", ThisKey="UserId", OtherKey="UserId", IsUnique=true, IsForeignKey=false)]
		public UserInfo UserInfo2
		{
			get
			{
				return this._UserInfo2.Entity;
			}
			set
			{
				UserInfo previousValue = this._UserInfo2.Entity;
				if (((previousValue != value) 
							|| (this._UserInfo2.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._UserInfo2.Entity = null;
						previousValue.UserInfo1 = null;
					}
					this._UserInfo2.Entity = value;
					if ((value != null))
					{
						value.UserInfo1 = this;
					}
					this.SendPropertyChanged("UserInfo2");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="UserInfo_UserInfo", Storage="_UserInfo1", ThisKey="UserId", OtherKey="UserId", IsForeignKey=true)]
		public UserInfo UserInfo1
		{
			get
			{
				return this._UserInfo1.Entity;
			}
			set
			{
				UserInfo previousValue = this._UserInfo1.Entity;
				if (((previousValue != value) 
							|| (this._UserInfo1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._UserInfo1.Entity = null;
						previousValue.UserInfo2 = null;
					}
					this._UserInfo1.Entity = value;
					if ((value != null))
					{
						value.UserInfo2 = this;
						this._UserId = value.UserId;
					}
					else
					{
						this._UserId = default(int);
					}
					this.SendPropertyChanged("UserInfo1");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.KeyInfo")]
	public partial class KeyInfo
	{
		
		private System.Nullable<int> _UserId;
		
		private System.Nullable<int> _PrivateKey;
		
		private System.Nullable<int> _PublicKey;
		
		public KeyInfo()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int")]
		public System.Nullable<int> UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this._UserId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PrivateKey", DbType="Int")]
		public System.Nullable<int> PrivateKey
		{
			get
			{
				return this._PrivateKey;
			}
			set
			{
				if ((this._PrivateKey != value))
				{
					this._PrivateKey = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PublicKey", DbType="Int")]
		public System.Nullable<int> PublicKey
		{
			get
			{
				return this._PublicKey;
			}
			set
			{
				if ((this._PublicKey != value))
				{
					this._PublicKey = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PasswordInfo")]
	public partial class PasswordInfo : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _PasswordId;
		
		private string _Password;
		
		private int _UserId;
		
		private string _LabelType;
		
		private System.DateTime _DateCreated;
		
		private string _Username;
		
		private string _SecurityAnswer;
		
		private EntityRef<PasswordInfo> _PasswordInfo2;
		
		private EntityRef<PasswordInfo> _PasswordInfo1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnPasswordIdChanging(int value);
    partial void OnPasswordIdChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnLabelTypeChanging(string value);
    partial void OnLabelTypeChanged();
    partial void OnDateCreatedChanging(System.DateTime value);
    partial void OnDateCreatedChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnSecurityAnswerChanging(string value);
    partial void OnSecurityAnswerChanged();
    #endregion
		
		public PasswordInfo()
		{
			this._PasswordInfo2 = default(EntityRef<PasswordInfo>);
			this._PasswordInfo1 = default(EntityRef<PasswordInfo>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PasswordId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int PasswordId
		{
			get
			{
				return this._PasswordId;
			}
			set
			{
				if ((this._PasswordId != value))
				{
					if (this._PasswordInfo1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPasswordIdChanging(value);
					this.SendPropertyChanging();
					this._PasswordId = value;
					this.SendPropertyChanged("PasswordId");
					this.OnPasswordIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(500)")]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LabelType", DbType="VarChar(20)")]
		public string LabelType
		{
			get
			{
				return this._LabelType;
			}
			set
			{
				if ((this._LabelType != value))
				{
					this.OnLabelTypeChanging(value);
					this.SendPropertyChanging();
					this._LabelType = value;
					this.SendPropertyChanged("LabelType");
					this.OnLabelTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateCreated", DbType="DateTime NOT NULL")]
		public System.DateTime DateCreated
		{
			get
			{
				return this._DateCreated;
			}
			set
			{
				if ((this._DateCreated != value))
				{
					this.OnDateCreatedChanging(value);
					this.SendPropertyChanging();
					this._DateCreated = value;
					this.SendPropertyChanged("DateCreated");
					this.OnDateCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="VarChar(30)")]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SecurityAnswer", DbType="VarChar(50)")]
		public string SecurityAnswer
		{
			get
			{
				return this._SecurityAnswer;
			}
			set
			{
				if ((this._SecurityAnswer != value))
				{
					this.OnSecurityAnswerChanging(value);
					this.SendPropertyChanging();
					this._SecurityAnswer = value;
					this.SendPropertyChanged("SecurityAnswer");
					this.OnSecurityAnswerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PasswordInfo_PasswordInfo", Storage="_PasswordInfo2", ThisKey="PasswordId", OtherKey="PasswordId", IsUnique=true, IsForeignKey=false)]
		public PasswordInfo PasswordInfo2
		{
			get
			{
				return this._PasswordInfo2.Entity;
			}
			set
			{
				PasswordInfo previousValue = this._PasswordInfo2.Entity;
				if (((previousValue != value) 
							|| (this._PasswordInfo2.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._PasswordInfo2.Entity = null;
						previousValue.PasswordInfo1 = null;
					}
					this._PasswordInfo2.Entity = value;
					if ((value != null))
					{
						value.PasswordInfo1 = this;
					}
					this.SendPropertyChanged("PasswordInfo2");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PasswordInfo_PasswordInfo", Storage="_PasswordInfo1", ThisKey="PasswordId", OtherKey="PasswordId", IsForeignKey=true)]
		public PasswordInfo PasswordInfo1
		{
			get
			{
				return this._PasswordInfo1.Entity;
			}
			set
			{
				PasswordInfo previousValue = this._PasswordInfo1.Entity;
				if (((previousValue != value) 
							|| (this._PasswordInfo1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._PasswordInfo1.Entity = null;
						previousValue.PasswordInfo2 = null;
					}
					this._PasswordInfo1.Entity = value;
					if ((value != null))
					{
						value.PasswordInfo2 = this;
						this._PasswordId = value.PasswordId;
					}
					else
					{
						this._PasswordId = default(int);
					}
					this.SendPropertyChanged("PasswordInfo1");
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
