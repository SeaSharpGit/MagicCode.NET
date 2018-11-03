
//******************************
// 自动生成请勿修改
// NuGet引用System.ComponentModel.DataAnnotations.dll
//******************************
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicCode
{
	public partial class Fc_email_body : BaseModel
	{
		public string Body_id { get; set; } = string.Empty;
		public string Email_title { get; set; } = string.Empty;
		public string Email_key { get; set; } = string.Empty;
		public string Body { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public DateTime Create_time { get; set; } = DateTime.Now;
		public DateTime Update_time { get; set; } = DateTime.Now;
		public string Create_user { get; set; } = string.Empty;
		public string Update_user { get; set; } = string.Empty;
	}

	public partial class Fc_group : BaseModel
	{
		[Key]
		public string Group_id { get; set; } = string.Empty;
		public string Group_name { get; set; } = string.Empty;
		public string Category_id { get; set; } = string.Empty;
		public string Title_id { get; set; } = string.Empty;
		public DateTime Create_time { get; set; } = DateTime.Now;
		public DateTime Update_time { get; set; } = DateTime.Now;
		public string Create_user { get; set; } = string.Empty;
		public string Update_user { get; set; } = string.Empty;
	}

	public partial class Fc_group_map : BaseModel
	{
		[Key]
		public string Map_id { get; set; } = string.Empty;
		public string Map_key { get; set; } = string.Empty;
		public string Group_id { get; set; } = string.Empty;
		public string Race_id { get; set; } = string.Empty;
		public string Role_id { get; set; } = string.Empty;
		public DateTime Create_time { get; set; } = DateTime.Now;
		public DateTime Update_time { get; set; } = DateTime.Now;
		public string Create_user { get; set; } = string.Empty;
		public string Update_user { get; set; } = string.Empty;
	}

	public partial class Fc_program : BaseModel
	{
		[Key]
		public string Program_id { get; set; } = string.Empty;
		public string Program_name { get; set; } = string.Empty;
		public double Score { get; set; } = 0;
		public string Category_id { get; set; } = string.Empty;
		public string Team_id { get; set; } = string.Empty;
		public string Title_id { get; set; } = string.Empty;
		public DateTime Create_time { get; set; } = DateTime.Now;
		public DateTime Update_time { get; set; } = DateTime.Now;
		public string Create_user { get; set; } = string.Empty;
		public string Update_user { get; set; } = string.Empty;
	}

	public partial class Fc_program_log : BaseModel
	{
		[Key]
		public string Log_id { get; set; } = string.Empty;
		public string Program_id { get; set; } = string.Empty;
		public string File_path { get; set; } = string.Empty;
		public string Schedule_id { get; set; } = string.Empty;
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Is_submit { get; set; } = 0;
		public bool Is_check { get; set; } = false;
		public string Description { get; set; } = string.Empty;
		public DateTime Create_time { get; set; } = DateTime.Now;
		public DateTime Update_time { get; set; } = DateTime.Now;
		public string Create_user { get; set; } = string.Empty;
		public string Update_user { get; set; } = string.Empty;
	}

	public partial class Fc_race : BaseModel
	{
		[Key]
		public string Race_id { get; set; } = string.Empty;
		public string Race_name { get; set; } = string.Empty;
		public DateTime Start_time { get; set; } = DateTime.Now;
		public DateTime End_time { get; set; } = DateTime.Now;
		public string Description { get; set; } = string.Empty;
		public DateTime Create_time { get; set; } = DateTime.Now;
		public DateTime Update_time { get; set; } = DateTime.Now;
		public string Create_user { get; set; } = string.Empty;
		public string Update_user { get; set; } = string.Empty;
	}

	public partial class Fc_race_category : BaseModel
	{
		[Key]
		public string Category_id { get; set; } = string.Empty;
		public string Category_name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string Race_id { get; set; } = string.Empty;
		public string Category_key { get; set; } = string.Empty;
		public DateTime Create_time { get; set; } = DateTime.Now;
		public DateTime Update_time { get; set; } = DateTime.Now;
		public string Create_user { get; set; } = string.Empty;
		public string Update_user { get; set; } = string.Empty;
	}

	public partial class Fc_race_schedule : BaseModel
	{
		[Key]
		public string Schedule_id { get; set; } = string.Empty;
		public string Schedule_name { get; set; } = string.Empty;
		public string File_path { get; set; } = string.Empty;
		public DateTime Start_time { get; set; } = DateTime.Now;
		public DateTime End_time { get; set; } = DateTime.Now;
		public string Category_id { get; set; } = string.Empty;
		public string Menu_url { get; set; } = string.Empty;
		public bool Is_score { get; set; } = false;
		public bool Is_check { get; set; } = false;
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Step { get; set; } = 0;
		public string Description { get; set; } = string.Empty;
		public double Score_ratio { get; set; } = 0;
		public DateTime Create_time { get; set; } = DateTime.Now;
		public DateTime Update_time { get; set; } = DateTime.Now;
		public string Create_user { get; set; } = string.Empty;
		public string Update_user { get; set; } = string.Empty;
	}

	public partial class Fc_race_standard : BaseModel
	{
		[Key]
		public string Standard_id { get; set; } = string.Empty;
		public string Schedule_id { get; set; } = string.Empty;
		public string Standard_name { get; set; } = string.Empty;
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Standard_score { get; set; } = 0;
		public string Description { get; set; } = string.Empty;
		public DateTime Create_time { get; set; } = DateTime.Now;
		public DateTime Update_time { get; set; } = DateTime.Now;
		public string Create_user { get; set; } = string.Empty;
		public string Update_user { get; set; } = string.Empty;
	}

	public partial class Fc_race_title : BaseModel
	{
		[Key]
		public string Title_id { get; set; } = string.Empty;
		public string Title { get; set; } = string.Empty;
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Threshold { get; set; } = 0;
		public string File_path { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string Category_id { get; set; } = string.Empty;
		public DateTime Create_time { get; set; } = DateTime.Now;
		public DateTime Update_time { get; set; } = DateTime.Now;
		public string Create_user { get; set; } = string.Empty;
		public string Update_user { get; set; } = string.Empty;
	}

	public partial class Fc_role : BaseModel
	{
		[Key]
		public string Role_id { get; set; } = string.Empty;
		public string Role_name { get; set; } = string.Empty;
		public string Tb_name { get; set; } = string.Empty;
		public string Role_auth { get; set; } = string.Empty;
		public string Role_key { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public DateTime Create_time { get; set; } = DateTime.Now;
		public DateTime Update_time { get; set; } = DateTime.Now;
		public string Create_user { get; set; } = string.Empty;
		public string Update_user { get; set; } = string.Empty;
	}

	public partial class Fc_school : BaseModel
	{
		[Key]
		public string School_id { get; set; } = string.Empty;
		public string School_name { get; set; } = string.Empty;
		public string Province_id { get; set; } = string.Empty;
		public string City_id { get; set; } = string.Empty;
		public bool Is_active { get; set; } = false;
		public string Address { get; set; } = string.Empty;
		public string Create_user { get; set; } = string.Empty;
		public string Update_user { get; set; } = string.Empty;
		public DateTime Create_time { get; set; } = DateTime.Now;
		public DateTime Update_time { get; set; } = DateTime.Now;
	}

	public partial class Fc_score : BaseModel
	{
		public string Score_id { get; set; } = string.Empty;
		public string Program_id { get; set; } = string.Empty;
		public string Schedule_id { get; set; } = string.Empty;
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Score { get; set; } = 0;
		public string Race_id { get; set; } = string.Empty;
		public DateTime Create_time { get; set; } = DateTime.Now;
		public DateTime Update_time { get; set; } = DateTime.Now;
		public string Create_user { get; set; } = string.Empty;
		public string Update_user { get; set; } = string.Empty;
	}

	public partial class Fc_score_detail : BaseModel
	{
		public string Detail_id { get; set; } = string.Empty;
		public string Score_log_id { get; set; } = string.Empty;
		public string Standard_id { get; set; } = string.Empty;
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Score { get; set; } = 0;
		public DateTime Create_time { get; set; } = DateTime.Now;
		public DateTime Update_time { get; set; } = DateTime.Now;
		public string Create_user { get; set; } = string.Empty;
		public string Update_user { get; set; } = string.Empty;
	}

	public partial class Fc_score_log : BaseModel
	{
		[Key]
		public string Score_log_id { get; set; } = string.Empty;
		public string Log_id { get; set; } = string.Empty;
		public string Program_id { get; set; } = string.Empty;
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Score { get; set; } = 0;
		public string Schedule_id { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string Create_user { get; set; } = string.Empty;
		public string Update_user { get; set; } = string.Empty;
		public DateTime Create_time { get; set; } = DateTime.Now;
		public DateTime Update_time { get; set; } = DateTime.Now;
	}

	public partial class Fc_team : BaseModel
	{
		[Key]
		public string Team_id { get; set; } = string.Empty;
		public string Team_name { get; set; } = string.Empty;
		public string School_id { get; set; } = string.Empty;
		public bool In_school { get; set; } = false;
		public string User_id { get; set; } = string.Empty;
		public string Race_id { get; set; } = string.Empty;
		public DateTime Create_time { get; set; } = DateTime.Now;
		public DateTime Update_time { get; set; } = DateTime.Now;
		public string Create_user { get; set; } = string.Empty;
		public string Update_user { get; set; } = string.Empty;
	}

	public partial class Fc_team_student : BaseModel
	{
		[Key]
		public string Student_id { get; set; } = string.Empty;
		public string Student_name { get; set; } = string.Empty;
		public string Phone { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Sex { get; set; } = 0;
		public string School_id { get; set; } = string.Empty;
		public string Team_id { get; set; } = string.Empty;
		public string Faculty { get; set; } = string.Empty;
		public string Major { get; set; } = string.Empty;
		public string Education { get; set; } = string.Empty;
		public string Duties { get; set; } = string.Empty;
		public string Identity_id { get; set; } = string.Empty;
		public string Grade { get; set; } = string.Empty;
		public string Entrance_time { get; set; } = string.Empty;
		public string Leaving_time { get; set; } = string.Empty;
		public DateTime Create_time { get; set; } = DateTime.Now;
		public DateTime Update_time { get; set; } = DateTime.Now;
		public string Create_user { get; set; } = string.Empty;
		public string Update_user { get; set; } = string.Empty;
	}

	public partial class Fc_team_teacher : BaseModel
	{
		[Key]
		public string Teacher_id { get; set; } = string.Empty;
		public string Team_id { get; set; } = string.Empty;
		public string Teacher_name { get; set; } = string.Empty;
		public string Phone { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Sex { get; set; } = 0;
		public string School_id { get; set; } = string.Empty;
		public string Faculty { get; set; } = string.Empty;
		public string Duties { get; set; } = string.Empty;
		public string Education { get; set; } = string.Empty;
		public string Identity_id { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public double Employ_rate { get; set; } = 0;
		public double Entrepreneurship_rate { get; set; } = 0;
		public string Create_user { get; set; } = string.Empty;
		public string Update_user { get; set; } = string.Empty;
		public DateTime Create_time { get; set; } = DateTime.Now;
		public DateTime Update_time { get; set; } = DateTime.Now;
	}

	public partial class Fc_user : BaseModel
	{
		[Key]
		public string User_id { get; set; } = string.Empty;
		public string User_name { get; set; } = string.Empty;
		public string Role_id { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public bool Is_active { get; set; } = false;
		public DateTime Create_time { get; set; } = DateTime.Now;
		public DateTime Update_time { get; set; } = DateTime.Now;
		public string Create_user { get; set; } = string.Empty;
		public string Update_user { get; set; } = string.Empty;
	}

}