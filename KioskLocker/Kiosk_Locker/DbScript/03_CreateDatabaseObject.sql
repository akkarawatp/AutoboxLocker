use [Minibox]
go

/****** Object:  Table [CF_KIOSK_SYSCONFIG]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [CF_KIOSK_SYSCONFIG](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[ms_kiosk_id] [bigint] NOT NULL,
	[mac_address] [varchar](50) NOT NULL,
	[ip_address] [varchar](50) NOT NULL,
	[location_code] [varchar](50) NOT NULL,
	[location_name] [varchar](255) NOT NULL,
	[login_sso] [char](1) NOT NULL,
	[kiosk_open_time] [varchar](20) NOT NULL,
	[kiosk_open24] [char](1) NOT NULL,
	[screen_saver_sec] [int] NOT NULL,
	[time_out_sec] [int] NOT NULL,
	[show_msg_sec] [int] NOT NULL,
	[payment_extend_sec] [int] NOT NULL,
	[pincode_len] [int] NOT NULL,
	[locker_webservice_url] [varchar](255) NOT NULL,
	[locker_pc_position] [int] NOT NULL,
	[sleep_time] [varchar](5) NOT NULL,
	[sleep_duration] [int] NOT NULL,
	[contact_center_telno] [varchar](50) NOT NULL,
	[alarm_webservice_url] [varchar](255) NULL,
	[interval_sync_transaction_min] [int] NOT NULL,
	[interval_sync_master_min] [int] NOT NULL,
	[interval_sync_log_min] [int] NOT NULL,
	[deposit_running_no] [varchar](50) NULL,
	[sync_to_kiosk] [char](1) NOT NULL,
	[sync_to_server] [char](1) NOT NULL,
	[machine_key] [varchar](1000) NULL,
 CONSTRAINT [PK_CF_SYSCONFIG] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterData],
 CONSTRAINT [AK_KEY_2_CF_SYSCO] UNIQUE NONCLUSTERED 
(
	[ms_kiosk_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterData]
) ON [MS_MasterData]
GO
/****** Object:  Table [MS_APP_SCREEN]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MS_APP_SCREEN](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[screen_name] [varchar](100) NOT NULL,
	[form_name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_MS_APP_SCREEN] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex],
 CONSTRAINT [AK_KEY_2_MS_APP_S2] UNIQUE NONCLUSTERED 
(
	[screen_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex]
) ON [MS_MasterIndex]
GO
/****** Object:  Table [MS_APP_STEP]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MS_APP_STEP](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[app_step_code] [varchar](50) NOT NULL,
	[ms_app_screen_id] [bigint] NOT NULL,
	[step_name_th] [varchar](255) NOT NULL,
	[step_name_en] [varchar](255) NOT NULL,
 CONSTRAINT [PK_MS_APP_STEP] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex],
 CONSTRAINT [AK_KEY_2_MS_APP_S] UNIQUE NONCLUSTERED 
(
	[ms_app_screen_id] ASC,
	[step_name_th] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex],
 CONSTRAINT [AK_KEY_3_MS_APP_S] UNIQUE NONCLUSTERED 
(
	[step_name_en] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex]
) ON [MS_MasterIndex]
GO
/****** Object:  Table [MS_CABINET]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MS_CABINET](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[ms_kiosk_id] [bigint] NOT NULL,
	[ms_cabinet_model_id] [bigint] NOT NULL,
	[cabinet_no] [varchar](100) NOT NULL,
	[order_layout] [int] NOT NULL,
	[service_rate_hour] [float] NOT NULL,
	[service_rate_limit_day] [float] NOT NULL,
	[deposit_amt] [float] NOT NULL,
	[active_status] [char](1) NOT NULL,
	[ms_cabinet_id] [bigint] NOT NULL,
	[sync_to_kiosk] [char](1) NOT NULL,
	[sync_to_server] [char](1) NOT NULL,
 CONSTRAINT [PK_MS2CABINET] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex],
 CONSTRAINT [IX_MS_CABINET] UNIQUE NONCLUSTERED 
(
	[ms_cabinet_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex]
) ON [MS_MasterIndex]
GO
/****** Object:  Table [MS_CABINET_MODEL]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MS_CABINET_MODEL](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[model_name] [varchar](50) NOT NULL,
	[cabinet_width] [float] NOT NULL,
	[cabinet_hight] [float] NOT NULL,
	[cabinet_deep] [float] NOT NULL,
	[locker_width] [float] NOT NULL,
	[locker_hight] [float] NOT NULL,
	[locker_deep] [float] NOT NULL,
	[service_rate_hour] [float] NOT NULL,
	[service_rate_limit_day] [float] NOT NULL,
	[deposit_amt] [float] NOT NULL,
	[locker_qty] [int] NOT NULL,
	[active_status] [char](1) NOT NULL,
 CONSTRAINT [PK_MS_CABINET_MODEL] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex],
 CONSTRAINT [AK_KEY_2_MS_CABIN2] UNIQUE NONCLUSTERED 
(
	[model_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex]
) ON [MS_MasterIndex]
GO
/****** Object:  Table [MS_DEVICE]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MS_DEVICE](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[device_name_th] [varchar](100) NOT NULL,
	[device_name_en] [varchar](100) NULL,
	[ms_device_type_id] [bigint] NOT NULL,
	[unit_value] [int] NOT NULL,
	[max_qty] [int] NOT NULL,
	[warning_qty] [int] NOT NULL,
	[critical_qty] [int] NOT NULL,
	[icon_white] [image] NULL,
	[icon_green] [image] NULL,
	[icon_red] [image] NULL,
	[device_order] [int] NOT NULL,
	[active_status] [char](1) NOT NULL,
 CONSTRAINT [PK_MS_DEVICE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex],
 CONSTRAINT [AK_KEY_2_MS_DEVIC3] UNIQUE NONCLUSTERED 
(
	[device_name_th] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex]
) ON [MS_MasterIndex] TEXTIMAGE_ON [MS_MasterData]
GO
/****** Object:  Table [MS_DEVICE_STATUS]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MS_DEVICE_STATUS](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[status_name] [varchar](100) NULL,
	[is_problem] [char](1) NULL,
	[ms_device_type_id] [bigint] NULL,
 CONSTRAINT [PK_MS_DEVICE_STATUS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex],
 CONSTRAINT [AK_KEY_2_MS_DEVIC] UNIQUE NONCLUSTERED 
(
	[status_name] ASC,
	[ms_device_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex]
) ON [MS_MasterIndex]
GO
/****** Object:  Table [MS_DEVICE_TYPE]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MS_DEVICE_TYPE](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[device_type_name_th] [varchar](100) NOT NULL,
	[device_type_name_en] [varchar](100) NOT NULL,
	[movement_direction] [varchar](2) NOT NULL,
	[active_status] [char](1) NOT NULL,
 CONSTRAINT [PK_MS_DEVICE_TYPE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex],
 CONSTRAINT [AK_KEY_2_MS_DEVIC2] UNIQUE NONCLUSTERED 
(
	[device_type_name_en] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex],
 CONSTRAINT [AK_KEY_3_MS_DEVIC2] UNIQUE NONCLUSTERED 
(
	[device_type_name_th] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex]
) ON [MS_MasterIndex]
GO
/****** Object:  Table [MS_KIOSK_ALARM]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MS_KIOSK_ALARM](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[ms_kiosk_id] [bigint] NOT NULL,
	[alarm_problem] [varchar](255) NOT NULL,
	[is_alarm] [char](1) NOT NULL,
	[is_send_alarm] [char](1) NOT NULL,
	[last_send_time] [datetime] NULL,
 CONSTRAINT [PK_MS_KIOSK_ALARM] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [TS_Data],
 CONSTRAINT [AK_KEY_2_MS_KI4SK] UNIQUE NONCLUSTERED 
(
	[ms_kiosk_id] ASC,
	[alarm_problem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [TS_Data]
) ON [TS_Data]
GO
/****** Object:  Table [MS_KIOSK_DEVICE]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MS_KIOSK_DEVICE](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[ms_kiosk_id] [bigint] NOT NULL,
	[ms_device_id] [bigint] NOT NULL,
	[max_qty] [int] NOT NULL,
	[warning_qty] [int] NOT NULL,
	[critical_qty] [int] NOT NULL,
	[current_qty] [int] NOT NULL,
	[current_money] [int] NULL,
	[ms_device_status_id] [bigint] NOT NULL,
	[comport_vid] [varchar](50) NULL,
	[driver_name1] [varchar](100) NULL,
	[driver_name2] [varchar](100) NULL,
	[sync_to_kiosk] [char](1) NOT NULL,
	[sync_to_server] [char](1) NOT NULL,
 CONSTRAINT [PK_MS_KIO2K_DEVICE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex],
 CONSTRAINT [AK_KEY_2_MS_K7OSK] UNIQUE NONCLUSTERED 
(
	[ms_kiosk_id] ASC,
	[ms_device_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex]
) ON [MS_MasterIndex]
GO
/****** Object:  Table [MS_KIOSK_PROMOTION]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MS_KIOSK_PROMOTION](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[ms_kiosk_id] [bigint] NOT NULL,
	[promotion_code] [varchar](50) NOT NULL,
	[promotion_name] [varchar](255) NOT NULL,
	[start_date] [datetime] NOT NULL,
	[end_date] [datetime] NOT NULL,
	[publish_status] [char](1) NOT NULL,
 CONSTRAINT [PK_MS_KIOSK_PROMOTION] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex],
 CONSTRAINT [AK_KEY_2_MS_KIOSK4] UNIQUE NONCLUSTERED 
(
	[promotion_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex]
) ON [MS_MasterIndex]
GO
/****** Object:  Table [MS_KIOSK_PROMOTION_HOUR]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MS_KIOSK_PROMOTION_HOUR](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[ms_kiosk_promotion_id] [bigint] NOT NULL,
	[ms_cabinet_model_id] [bigint] NOT NULL,
	[promotion_hour] [int] NOT NULL,
	[service_rate] [int] NOT NULL,
 CONSTRAINT [PK_MS_KIOSK_PROMOTION_HOUR] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex],
 CONSTRAINT [AK_KEY_2_MS_KIOSK5] UNIQUE NONCLUSTERED 
(
	[ms_kiosk_promotion_id] ASC,
	[ms_cabinet_model_id] ASC,
	[promotion_hour] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex]
) ON [MS_MasterIndex]
GO
/****** Object:  Table [MS_LOCKER]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MS_LOCKER](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[locker_name] [varchar](50) NOT NULL,
	[layout_name] [varchar](50) NULL,
	[ms_kiosk_id] [bigint] NOT NULL,
	[ms_cabinet_id] [bigint] NOT NULL,
	[model_name] [varchar](50) NOT NULL,
	[pin_solenoid] [int] NOT NULL,
	[pin_led] [int] NOT NULL,
	[pin_sensor] [varchar](1) NOT NULL,
	[open_close_status] [char](1) NOT NULL,
	[current_available] [char](1) NOT NULL,
	[active_status] [char](1) NOT NULL,
	[ms_locker_id] [bigint] NOT NULL,
	[sync_to_server] [char](1) NOT NULL,
	[sync_to_kiosk] [char](1) NOT NULL,
 CONSTRAINT [PK_MS_LOCKER] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex],
 CONSTRAINT [AK_KEY_2_MS_LOCKE2] UNIQUE NONCLUSTERED 
(
	[locker_name] ASC,
	[ms_kiosk_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex],
 CONSTRAINT [IX_MS_LOCKER] UNIQUE NONCLUSTERED 
(
	[ms_locker_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex]
) ON [MS_MasterIndex]
GO
/****** Object:  Table [MS_MASTER_MONITORING_ALARM]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MS_MASTER_MONITORING_ALARM](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[ms_master_monitoring_type_id] [bigint] NULL,
	[alarm_code] [varchar](255) NULL,
	[alarm_problem] [varchar](255) NULL,
	[eng_desc] [varchar](255) NULL,
	[tha_desc] [varchar](255) NULL,
	[sms_message] [varchar](255) NULL,
 CONSTRAINT [PK_MS_MASTER_MONITORING_ALARM] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex],
 CONSTRAINT [AK_KEY_3_MS_MASTE] UNIQUE NONCLUSTERED 
(
	[alarm_problem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex]
) ON [MS_MasterIndex]
GO
/****** Object:  Table [MS_SERVICE_RATE]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MS_SERVICE_RATE](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[ms_kiosk_id] [bigint] NOT NULL,
 CONSTRAINT [PK_MS_SERVICE_RATE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex],
 CONSTRAINT [AK_KEY_2_MS_SERVI2] UNIQUE NONCLUSTERED 
(
	[ms_kiosk_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex]
) ON [MS_MasterIndex]
GO
/****** Object:  Table [MS_SERVICE_RATE_DEPOSIT]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MS_SERVICE_RATE_DEPOSIT](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[ms_service_rate_id] [bigint] NOT NULL,
	[ms_cabinet_model_id] [bigint] NOT NULL,
	[deposit_rate] [int] NOT NULL,
 CONSTRAINT [PK_MS_SERVICE_RATE_DEPOSIT] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex],
 CONSTRAINT [AK_KEY_2_MS_SERVI4] UNIQUE NONCLUSTERED 
(
	[ms_service_rate_id] ASC,
	[ms_cabinet_model_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex]
) ON [MS_MasterIndex]
GO
/****** Object:  Table [MS_SERVICE_RATE_FINE]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MS_SERVICE_RATE_FINE](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[ms_service_rate_id] [bigint] NOT NULL,
	[ms_cabinet_model_id] [bigint] NOT NULL,
	[fine_rate] [int] NOT NULL,
 CONSTRAINT [PK_MS_SERVICE_RATE_FINE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex],
 CONSTRAINT [AK_KEY_2_MS_S3RVI] UNIQUE NONCLUSTERED 
(
	[ms_service_rate_id] ASC,
	[ms_cabinet_model_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex]
) ON [MS_MasterIndex]
GO
/****** Object:  Table [MS_SERVICE_RATE_HOUR]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MS_SERVICE_RATE_HOUR](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[ms_service_rate_id] [bigint] NOT NULL,
	[ms_cabinet_model_id] [bigint] NOT NULL,
	[service_hour] [int] NOT NULL,
	[service_rate] [int] NOT NULL,
 CONSTRAINT [PK_MS_SERVICE_RATE_HOUR] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex],
 CONSTRAINT [AK_KEY_2_MS_SERVI3] UNIQUE NONCLUSTERED 
(
	[ms_service_rate_id] ASC,
	[ms_cabinet_model_id] ASC,
	[service_hour] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex]
) ON [MS_MasterIndex]
GO
/****** Object:  Table [MS_SERVICE_RATE_OVERNIGHT]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MS_SERVICE_RATE_OVERNIGHT](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[ms_service_rate_id] [bigint] NOT NULL,
	[ms_cabinet_model_id] [bigint] NOT NULL,
	[service_rate_day] [int] NOT NULL,
 CONSTRAINT [PK_MS_SERVICE_RATE_OVERNIGHT] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex],
 CONSTRAINT [AK_KEY_2_MS_SERVI] UNIQUE NONCLUSTERED 
(
	[ms_service_rate_id] ASC,
	[ms_cabinet_model_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex]
) ON [MS_MasterIndex]
GO
/****** Object:  Table [TB_DEPOSIT_TRANSACTION]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TB_DEPOSIT_TRANSACTION](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[trans_no] [varchar](50) NOT NULL,
	[trans_start_time] [datetime] NOT NULL,
	[trans_end_time] [datetime] NULL,
	[ms_kiosk_id] [bigint] NOT NULL,
	[ms_locker_id] [bigint] NULL,
	[pin_code] [varchar](50) NULL,
	[cust_image] [image] NULL,
	[service_rate] [float] NOT NULL,
	[service_rate_limit_day] [float] NOT NULL,
	[deposit_amt] [float] NOT NULL,
	[paid_time] [datetime] NULL,
	[receive_coin1] [int] NOT NULL,
	[receive_coin2] [int] NOT NULL,
	[receive_coin5] [int] NOT NULL,
	[receive_coin10] [int] NOT NULL,
	[receive_banknote20] [int] NOT NULL,
	[receive_banknote50] [int] NOT NULL,
	[receive_banknote100] [int] NOT NULL,
	[receive_banknote500] [int] NOT NULL,
	[receive_banknote1000] [int] NOT NULL,
	[change_coin1] [int] NOT NULL,
	[change_coin2] [int] NOT NULL,
	[change_coin5] [int] NOT NULL,
	[change_coin10] [int] NOT NULL,
	[change_banknote20] [int] NOT NULL,
	[change_banknote50] [int] NOT NULL,
	[change_banknote100] [int] NOT NULL,
	[change_banknote500] [int] NOT NULL,
	[trans_status] [char](1) NOT NULL,
	[ms_app_screen_id] [bigint] NOT NULL,
	[ms_app_step_id] [bigint] NOT NULL,
	[sync_to_server] [char](1) NOT NULL,
 CONSTRAINT [PK_TB_SERVICE_TRANSACTION] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [TS_Index],
 CONSTRAINT [AK_KEY_2_TB_SERVI] UNIQUE NONCLUSTERED 
(
	[trans_no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [TS_Index]
) ON [TS_Index] TEXTIMAGE_ON [TS_Data]
GO
/****** Object:  Table [TB_FILL_MONEY]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TB_FILL_MONEY](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[ms_kiosk_id] [bigint] NOT NULL,
	[coin_money] [float] NOT NULL,
	[banknote_money] [float] NOT NULL,
	[checkout_receive_money] [char](1) NOT NULL,
	[checkout_datetime] [datetime] NULL,
	[change1_remain] [int] NOT NULL,
	[change2_remain] [int] NOT NULL,
	[change5_remain] [int] NOT NULL,
	[change10_remain] [int] NOT NULL,
	[change20_remain] [int] NOT NULL,
	[change50_remain] [int] NOT NULL,
	[change100_remain] [int] NOT NULL,
	[change500_remain] [int] NOT NULL,
	[checkin_change_money] [char](1) NOT NULL,
	[checkin_datetime] [datetime] NULL,
	[total_money_remain] [float] NOT NULL,
	[is_confirm] [char](1) NOT NULL,
	[confirm_cancel_datetime] [datetime] NOT NULL,
	[change1_qty] [int] NOT NULL,
	[change2_qty] [int] NOT NULL,
	[change5_qty] [int] NOT NULL,
	[change10_qty] [int] NOT NULL,
	[change20_qty] [int] NOT NULL,
	[change50_qty] [int] NOT NULL,
	[change100_qty] [int] NOT NULL,
	[change500_qty] [int] NOT NULL,
	[sync_to_server] [char](1) NOT NULL,
 CONSTRAINT [PK_TB_FILL_MONEY] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [TS_Index]
) ON [TS_Index]
GO
/****** Object:  Table [TB_LOG_ERROR]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TB_LOG_ERROR](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[ms_kiosk_id] [bigint] NOT NULL,
	[class_name] [varchar](100) NOT NULL,
	[function_name] [varchar](100) NOT NULL,
	[error_time] [datetime] NOT NULL,
	[error_desc] [varchar](500) NOT NULL,
	[deposit_trans_no] [varchar](50) NULL,
	[pickup_trans_no] [varchar](50) NULL,
	[staff_console_trans_no] [varchar](50) NULL,
	[ms_app_screen_id] [bigint] NULL,
	[ms_app_step_id] [bigint] NULL,
	[sync_to_server] [char](1) NOT NULL,
 CONSTRAINT [PK_TB_LOG_ERROR] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [TS_Data]
) ON [TS_Data]
GO
/****** Object:  Table [TB_LOG_KIOSK_AGENT]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TB_LOG_KIOSK_AGENT](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[ms_kiosk_id] [bigint] NOT NULL,
	[log_type] [char](1) NOT NULL,
	[log_message] [text] NOT NULL,
	[class_name] [varchar](100) NOT NULL,
	[function_name] [varchar](100) NOT NULL,
	[line_no] [int] NOT NULL,
	[sync_to_server] [char](1) NOT NULL,
	[log_time] [datetime] NOT NULL,
 CONSTRAINT [PK_TB_LOG_KIOSK_AGENT] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [TS_Index]
) ON [TS_Index] TEXTIMAGE_ON [TS_Data]
GO
/****** Object:  Table [TB_LOG_TRANSACTION_ACTIVITY]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TB_LOG_TRANSACTION_ACTIVITY](
	[id] [bigint] NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[ms_kiosk_id] [bigint] NOT NULL,
	[trans_date] [datetime] NOT NULL,
	[deposit_trans_no] [varchar](50) NULL,
	[pickup_trans_no] [varchar](50) NULL,
	[staff_console_trans_no] [varchar](50) NULL,
	[ms_app_screen_id] [bigint] NOT NULL,
	[ms_app_step_id] [bigint] NOT NULL,
	[log_desc] [varchar](500) NOT NULL,
	[is_problem] [char](1) NOT NULL,
	[sync_to_server] [char](1) NOT NULL,
 CONSTRAINT [PK_TB_LOG_TRANSACTION_ACTIVITY] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [TS_Index]
) ON [TS_Index]
GO
/****** Object:  Table [TB_PICKUP_TRANSACTION]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TB_PICKUP_TRANSACTION](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[transaction_no] [varchar](50) NULL,
	[trans_start_time] [datetime] NULL,
	[trans_end_time] [datetime] NULL,
	[ms_kiosk_id] [bigint] NOT NULL,
	[ms_locker_id] [bigint] NULL,
	[deposit_trans_no] [varchar](50) NULL,
	[lost_qr_code] [char](1) NOT NULL,
	[service_amt] [int] NOT NULL,
	[is_fine] [char](1) NOT NULL,
	[fine_amt] [int] NOT NULL,
	[pickup_time] [datetime] NULL,
	[paid_time] [datetime] NULL,
	[cust_image] [image] NULL,
	[receive_coin1] [int] NOT NULL,
	[receive_coin2] [int] NOT NULL,
	[receive_coin5] [int] NOT NULL,
	[receive_coin10] [int] NOT NULL,
	[receive_banknote20] [int] NOT NULL,
	[receive_banknote50] [int] NOT NULL,
	[receive_banknote100] [int] NOT NULL,
	[receive_banknote500] [int] NOT NULL,
	[receive_banknote1000] [int] NOT NULL,
	[change_coin1] [int] NOT NULL,
	[change_coin2] [int] NOT NULL,
	[change_coin5] [int] NOT NULL,
	[change_coin10] [int] NOT NULL,
	[change_banknote20] [int] NOT NULL,
	[change_banknote50] [int] NOT NULL,
	[change_banknote100] [int] NOT NULL,
	[change_banknote500] [int] NOT NULL,
	[trans_status] [char](1) NOT NULL,
	[ms_app_screen_id] [bigint] NULL,
	[ms_app_step_id] [bigint] NOT NULL,
	[sync_to_server] [char](1) NOT NULL,
 CONSTRAINT [PK_TB_PICKUP_TRANSACTION] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [TS_Index],
 CONSTRAINT [AK_KEY_23TB_PICKU] UNIQUE NONCLUSTERED 
(
	[transaction_no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [TS_Index]
) ON [TS_Index] TEXTIMAGE_ON [TS_Data]
GO
/****** Object:  Table [TB_STAFF_CONSOLE_TRANSACTION]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TB_STAFF_CONSOLE_TRANSACTION](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[trans_no] [varchar](50) NOT NULL,
	[trans_start_time] [datetime] NOT NULL,
	[trans_end_time] [datetime] NULL,
	[ms_kiosk_id] [bigint] NOT NULL,
	[login_username] [varchar](50) NULL,
	[login_first_name] [varchar](100) NULL,
	[login_last_name] [varchar](100) NULL,
	[login_company_name] [varchar](255) NULL,
	[login_by] [char](1) NULL,
	[ms_app_step_id] [bigint] NULL,
	[sync_to_server] [char](1) NOT NULL,
 CONSTRAINT [PK_TB_STAFF_CONSOLE_TRANSACTIO] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [TS_Index],
 CONSTRAINT [AK_KEY_2_TB_STAFF] UNIQUE NONCLUSTERED 
(
	[trans_no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [TS_Index]
) ON [TS_Index]
GO
/****** Object:  View [v_kiosk_device_info]    Script Date: 31/12/2560 1:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE TABLE [dbo].[MS_NOT_USE_PINCODE](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[created_by] [varchar](100) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [varchar](100) NULL,
	[updated_date] [datetime] NULL,
	[not_use_pincode] [varchar](100) NOT NULL,
 CONSTRAINT [PK_MS_NOT_USE_PINCODE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterData]
) ON [MS_MasterData]
GO

ALTER TABLE [dbo].[MS_NOT_USE_PINCODE] ADD  CONSTRAINT [DF_MS_NOT_USE_PINCODE_created_date]  DEFAULT (getdate()) FOR [created_date]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_NOT_USE_PINCODE', @level2type=N'COLUMN',@level2name=N'id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_NOT_USE_PINCODE', @level2type=N'COLUMN',@level2name=N'created_by'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_NOT_USE_PINCODE', @level2type=N'COLUMN',@level2name=N'created_date'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_NOT_USE_PINCODE', @level2type=N'COLUMN',@level2name=N'updated_by'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_NOT_USE_PINCODE', @level2type=N'COLUMN',@level2name=N'updated_date'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสที่ห้ามใช้' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_NOT_USE_PINCODE', @level2type=N'COLUMN',@level2name=N'not_use_pincode'
GO

/****** Object:  Index [IX_MS_NOT_USE_PINCODE]    Script Date: 11/2/2561 16:15:25 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_MS_NOT_USE_PINCODE] ON [dbo].[MS_NOT_USE_PINCODE]
(
	[not_use_pincode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex]
GO







CREATE view [v_kiosk_device_info] as 
select dt.id device_type_id, dt.device_type_name_th,dt.device_type_name_en, dt.movement_direction,dt.active_status type_active_status,
 d.id device_id, d.device_name_th, d.device_name_en, d.unit_value,d.max_qty,d.warning_qty,d.critical_qty,
 d.icon_white,d.icon_green,d.icon_red, d.device_order, d.active_status device_active_status,
 kd.id kiosk_device_id, kd.max_qty kiosk_max_qty,kd.warning_qty kiosk_warning_qty, kd.critical_qty kiosk_critical_qty, kd.current_qty kiosk_current_qty, kd.current_money kiosk_current_money,
 kd.comport_vid,kd.driver_name1,kd.driver_name2, 
 ds.id device_status_id, ds.status_name current_status_name,ds.is_problem,
 kd.ms_kiosk_id
from MS_DEVICE_TYPE dt 
inner join dbo.MS_DEVICE d on d.ms_device_type_id=dt.id
inner join ms_kiosk_device kd on d.id=kd.ms_device_id
inner join ms_device_status ds on ds.id=kd.ms_device_status_id




GO
/****** Object:  Index [IX_MS_CABINET_1]    Script Date: 31/12/2560 1:48:27 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_MS_CABINET_1] ON [MS_CABINET]
(
	[ms_kiosk_id] ASC,
	[order_layout] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [TS_Data]
GO
/****** Object:  Index [Index_1]    Script Date: 31/12/2560 1:48:27 ******/
CREATE NONCLUSTERED INDEX [Index_1] ON [MS_MASTER_MONITORING_ALARM]
(
	[ms_master_monitoring_type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex]
GO
/****** Object:  Index [Index_1]    Script Date: 31/12/2560 1:48:27 ******/
CREATE NONCLUSTERED INDEX [Index_1] ON [TB_DEPOSIT_TRANSACTION]
(
	[trans_start_time] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [TS_Index]
GO
/****** Object:  Index [Index_2]    Script Date: 31/12/2560 1:48:27 ******/
CREATE NONCLUSTERED INDEX [Index_2] ON [TB_DEPOSIT_TRANSACTION]
(
	[ms_locker_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [TS_Index]
GO
/****** Object:  Index [Index_1]    Script Date: 31/12/2560 1:48:27 ******/
CREATE NONCLUSTERED INDEX [Index_1] ON [TB_FILL_MONEY]
(
	[ms_kiosk_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [TS_Index]
GO
/****** Object:  Index [Index_2]    Script Date: 31/12/2560 1:48:27 ******/
CREATE NONCLUSTERED INDEX [Index_2] ON [TB_FILL_MONEY]
(
	[confirm_cancel_datetime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [TS_Index]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Index_1]    Script Date: 31/12/2560 1:48:27 ******/
CREATE NONCLUSTERED INDEX [Index_1] ON [TB_LOG_KIOSK_AGENT]
(
	[class_name] ASC,
	[function_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [TS_Index]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Index_2]    Script Date: 31/12/2560 1:48:27 ******/
CREATE NONCLUSTERED INDEX [Index_2] ON [TB_LOG_KIOSK_AGENT]
(
	[ms_kiosk_id] ASC,
	[log_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [TS_Index]
GO
/****** Object:  Index [Index_1]    Script Date: 31/12/2560 1:48:27 ******/
CREATE NONCLUSTERED INDEX [Index_1] ON [TB_LOG_TRANSACTION_ACTIVITY]
(
	[trans_date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex]
GO
/****** Object:  Index [Index_3]    Script Date: 31/12/2560 1:48:27 ******/
CREATE NONCLUSTERED INDEX [Index_3] ON [TB_LOG_TRANSACTION_ACTIVITY]
(
	[ms_app_screen_id] ASC,
	[ms_app_step_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [MS_MasterIndex]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [AK_KEY_2_TB_PICKU]    Script Date: 31/12/2560 1:48:27 ******/
CREATE NONCLUSTERED INDEX [AK_KEY_2_TB_PICKU] ON [TB_PICKUP_TRANSACTION]
(
	[deposit_trans_no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [TS_Index]
GO
/****** Object:  Index [Index_1]    Script Date: 31/12/2560 1:48:27 ******/
CREATE NONCLUSTERED INDEX [Index_1] ON [TB_PICKUP_TRANSACTION]
(
	[trans_start_time] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [TS_Index]
GO
/****** Object:  Index [Index_2]    Script Date: 31/12/2560 1:48:27 ******/
CREATE NONCLUSTERED INDEX [Index_2] ON [TB_PICKUP_TRANSACTION]
(
	[ms_locker_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [TS_Index]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Index_1]    Script Date: 31/12/2560 1:48:27 ******/
CREATE NONCLUSTERED INDEX [Index_1] ON [TB_STAFF_CONSOLE_TRANSACTION]
(
	[login_username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [TS_Index]
GO
ALTER TABLE [CF_KIOSK_SYSCONFIG] ADD  CONSTRAINT [DF__CF_SYSCON__creat__278EDA44]  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [CF_KIOSK_SYSCONFIG] ADD  CONSTRAINT [DF_CF_KIOSK_SYSCONFIG_kiosk_open24]  DEFAULT ('N') FOR [kiosk_open24]
GO
ALTER TABLE [CF_KIOSK_SYSCONFIG] ADD  CONSTRAINT [DF__CF_KIOSK___locke__42CCE065]  DEFAULT ((7)) FOR [locker_pc_position]
GO
ALTER TABLE [CF_KIOSK_SYSCONFIG] ADD  CONSTRAINT [DF__CF_KIOSK___inter__00CA12DE]  DEFAULT ((1)) FOR [interval_sync_transaction_min]
GO
ALTER TABLE [CF_KIOSK_SYSCONFIG] ADD  CONSTRAINT [DF__CF_KIOSK___inter__01BE3717]  DEFAULT ((10)) FOR [interval_sync_master_min]
GO
ALTER TABLE [CF_KIOSK_SYSCONFIG] ADD  CONSTRAINT [DF__CF_KIOSK___inter__02B25B50]  DEFAULT ((1)) FOR [interval_sync_log_min]
GO
ALTER TABLE [CF_KIOSK_SYSCONFIG] ADD  CONSTRAINT [DF_CF_KIOSK_SYSCONFIG_sync_to_kiosk]  DEFAULT ('N') FOR [sync_to_kiosk]
GO
ALTER TABLE [CF_KIOSK_SYSCONFIG] ADD  CONSTRAINT [DF_CF_KIOSK_SYSCONFIG_sync_to_server]  DEFAULT ('N') FOR [sync_to_server]
GO
ALTER TABLE [MS_APP_SCREEN] ADD  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [MS_APP_STEP] ADD  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [MS_CABINET] ADD  CONSTRAINT [DF__MS_CABINE__creat__6A30C649]  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [MS_CABINET] ADD  CONSTRAINT [DF__MS_CABINE__activ__6B24EA82]  DEFAULT ('Y') FOR [active_status]
GO
ALTER TABLE [MS_CABINET] ADD  CONSTRAINT [DF_MS_CABINET_sync_to_kiosk]  DEFAULT ('N') FOR [sync_to_kiosk]
GO
ALTER TABLE [MS_CABINET] ADD  CONSTRAINT [DF_MS_CABINET_sync_to_server]  DEFAULT ('N') FOR [sync_to_server]
GO
ALTER TABLE [MS_CABINET_MODEL] ADD  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [MS_CABINET_MODEL] ADD  DEFAULT ('Y') FOR [active_status]
GO
ALTER TABLE [MS_DEVICE] ADD  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [MS_DEVICE] ADD  DEFAULT ('Y') FOR [active_status]
GO
ALTER TABLE [MS_DEVICE_STATUS] ADD  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [MS_DEVICE_TYPE] ADD  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [MS_DEVICE_TYPE] ADD  DEFAULT ('0') FOR [movement_direction]
GO
ALTER TABLE [MS_DEVICE_TYPE] ADD  DEFAULT ('Y') FOR [active_status]
GO
ALTER TABLE [MS_KIOSK_ALARM] ADD  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [MS_KIOSK_ALARM] ADD  DEFAULT ('N') FOR [is_alarm]
GO
ALTER TABLE [MS_KIOSK_ALARM] ADD  DEFAULT ('N') FOR [is_send_alarm]
GO
ALTER TABLE [MS_KIOSK_DEVICE] ADD  CONSTRAINT [DF__MS_KIOSK___creat__567ED357]  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [MS_KIOSK_DEVICE] ADD  CONSTRAINT [DF_MS_KIOSK_DEVICE_sync_to_kiosk]  DEFAULT ('N') FOR [sync_to_kiosk]
GO
ALTER TABLE [MS_KIOSK_DEVICE] ADD  CONSTRAINT [DF_MS_KIOSK_DEVICE_sync_to_server]  DEFAULT ('N') FOR [sync_to_server]
GO
ALTER TABLE [MS_KIOSK_PROMOTION] ADD  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [MS_KIOSK_PROMOTION_HOUR] ADD  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [MS_LOCKER] ADD  CONSTRAINT [DF__MS_LOCKER__creat__73BA3083]  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [MS_LOCKER] ADD  CONSTRAINT [DF__MS_LOCKER__open___74AE54BC]  DEFAULT ('C') FOR [open_close_status]
GO
ALTER TABLE [MS_LOCKER] ADD  CONSTRAINT [DF__MS_LOCKER__curre__75A278F5]  DEFAULT ('Y') FOR [current_available]
GO
ALTER TABLE [MS_LOCKER] ADD  CONSTRAINT [DF__MS_LOCKER__activ__76969D2E]  DEFAULT ('Y') FOR [active_status]
GO
ALTER TABLE [MS_LOCKER] ADD  CONSTRAINT [DF__MS_LOCKER__sync___778AC167]  DEFAULT ('N') FOR [sync_to_server]
GO
ALTER TABLE [MS_LOCKER] ADD  DEFAULT ('Y') FOR [sync_to_kiosk]
GO
ALTER TABLE [MS_MASTER_MONITORING_ALARM] ADD  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [MS_SERVICE_RATE] ADD  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [MS_SERVICE_RATE_DEPOSIT] ADD  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [MS_SERVICE_RATE_FINE] ADD  CONSTRAINT [DF__MS_SERVIC__creat__2CBDA3B5]  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [MS_SERVICE_RATE_FINE] ADD  CONSTRAINT [DF__MS_SERVIC__fine___2DB1C7EE]  DEFAULT ((0)) FOR [fine_rate]
GO
ALTER TABLE [MS_SERVICE_RATE_HOUR] ADD  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [MS_SERVICE_RATE_OVERNIGHT] ADD  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF__TB_SERVIC__creat__7E37BEF6]  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF__TB_SERVIC__servi__01142BA1]  DEFAULT ((0)) FOR [service_rate]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF_TB_SERVICE_TRANSACTION_service_rate_limit_day]  DEFAULT ((0)) FOR [service_rate_limit_day]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF_TB_SERVICE_TRANSACTION_deposit_amt]  DEFAULT ((0)) FOR [deposit_amt]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF__TB_SERVIC__recei__02FC7413]  DEFAULT ((0)) FOR [receive_coin1]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF__TB_SERVIC__recei__03F0984C]  DEFAULT ((0)) FOR [receive_coin2]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF__TB_SERVIC__recei__04E4BC85]  DEFAULT ((0)) FOR [receive_coin5]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF__TB_SERVIC__recei__05D8E0BE]  DEFAULT ((0)) FOR [receive_coin10]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF__TB_SERVIC__recei__06CD04F7]  DEFAULT ((0)) FOR [receive_banknote20]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF__TB_SERVIC__recei__07C12930]  DEFAULT ((0)) FOR [receive_banknote50]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF__TB_SERVIC__recei__08B54D69]  DEFAULT ((0)) FOR [receive_banknote100]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF__TB_SERVIC__recei__09A971A2]  DEFAULT ((0)) FOR [receive_banknote500]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF__TB_SERVIC__recei__0A9D95DB]  DEFAULT ((0)) FOR [receive_banknote1000]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF__TB_SERVIC__chang__0B91BA14]  DEFAULT ((0)) FOR [change_coin1]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF__TB_SERVIC__chang__0C85DE4D]  DEFAULT ((0)) FOR [change_coin2]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF__TB_SERVIC__chang__0D7A0286]  DEFAULT ((0)) FOR [change_coin5]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF__TB_SERVIC__chang__0E6E26BF]  DEFAULT ((0)) FOR [change_coin10]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF__TB_SERVIC__chang__0F624AF8]  DEFAULT ((0)) FOR [change_banknote20]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF__TB_SERVIC__chang__10566F31]  DEFAULT ((0)) FOR [change_banknote50]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF__TB_SERVIC__chang__114A936A]  DEFAULT ((0)) FOR [change_banknote100]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF__TB_SERVIC__chang__123EB7A3]  DEFAULT ((0)) FOR [change_banknote500]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF__TB_SERVIC__trans__1332DBDC]  DEFAULT ('0') FOR [trans_status]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF__TB_SERVIC__ms_ap__155B1B70]  DEFAULT ((0)) FOR [ms_app_screen_id]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF__TB_SERVIC__ms_ap__14270015]  DEFAULT ((0)) FOR [ms_app_step_id]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] ADD  CONSTRAINT [DF__TB_SERVIC__sync___151B244E]  DEFAULT ('N') FOR [sync_to_server]
GO
ALTER TABLE [TB_FILL_MONEY] ADD  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [TB_FILL_MONEY] ADD  DEFAULT ('N') FOR [checkout_receive_money]
GO
ALTER TABLE [TB_FILL_MONEY] ADD  DEFAULT ('N') FOR [checkin_change_money]
GO
ALTER TABLE [TB_FILL_MONEY] ADD  CONSTRAINT [DF__TB_FILL_M__is_co__153B1FDF]  DEFAULT ('Z') FOR [is_confirm]
GO
ALTER TABLE [TB_FILL_MONEY] ADD  CONSTRAINT [DF_TB_FILL_MONEY_sync_to_server]  DEFAULT ('N') FOR [sync_to_server]
GO
ALTER TABLE [TB_LOG_ERROR] ADD  CONSTRAINT [DF__TB_LOG_ER__creat__0539C240]  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [TB_LOG_ERROR] ADD  CONSTRAINT [DF__TB_LOG_ER__sync___062DE679]  DEFAULT ('N') FOR [sync_to_server]
GO
ALTER TABLE [TB_LOG_KIOSK_AGENT] ADD  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [TB_LOG_KIOSK_AGENT] ADD  DEFAULT ('N') FOR [sync_to_server]
GO
ALTER TABLE [TB_LOG_TRANSACTION_ACTIVITY] ADD  CONSTRAINT [DF__TB_LOG_TR__creat__52442E1F]  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [TB_LOG_TRANSACTION_ACTIVITY] ADD  CONSTRAINT [DF__TB_LOG_TR__is_pr__53385258]  DEFAULT ('N') FOR [is_problem]
GO
ALTER TABLE [TB_LOG_TRANSACTION_ACTIVITY] ADD  CONSTRAINT [DF__TB_LOG_TR__sync___542C7691]  DEFAULT ('N') FOR [sync_to_server]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF__TB_PICKUP__creat__19DFD96B]  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF_TB_PICKUP_TRANSACTION_lost_qr_code]  DEFAULT ('Z') FOR [lost_qr_code]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF_TB_PICKUP_TRANSACTION_is_fine]  DEFAULT ('N') FOR [is_fine]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF_TB_PICKUP_TRANSACTION_fine_amt]  DEFAULT ((0)) FOR [fine_amt]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF__TB_PICKUP__recei__1BC821DD]  DEFAULT ((0)) FOR [receive_coin1]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF__TB_PICKUP__recei__1CBC4616]  DEFAULT ((0)) FOR [receive_coin2]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF__TB_PICKUP__recei__1DB06A4F]  DEFAULT ((0)) FOR [receive_coin5]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF__TB_PICKUP__recei__1EA48E88]  DEFAULT ((0)) FOR [receive_coin10]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF__TB_PICKUP__recei__1F98B2C1]  DEFAULT ((0)) FOR [receive_banknote20]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF__TB_PICKUP__recei__208CD6FA]  DEFAULT ((0)) FOR [receive_banknote50]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF__TB_PICKUP__recei__2180FB33]  DEFAULT ((0)) FOR [receive_banknote100]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF__TB_PICKUP__recei__22751F6C]  DEFAULT ((0)) FOR [receive_banknote500]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF__TB_PICKUP__recei__236943A5]  DEFAULT ((0)) FOR [receive_banknote1000]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF__TB_PICKUP__chang__245D67DE]  DEFAULT ((0)) FOR [change_coin1]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF__TB_PICKUP__chang__25518C17]  DEFAULT ((0)) FOR [change_coin2]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF__TB_PICKUP__chang__2645B050]  DEFAULT ((0)) FOR [change_coin5]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF__TB_PICKUP__chang__2739D489]  DEFAULT ((0)) FOR [change_coin10]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF__TB_PICKUP__chang__282DF8C2]  DEFAULT ((0)) FOR [change_banknote20]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF__TB_PICKUP__chang__29221CFB]  DEFAULT ((0)) FOR [change_banknote50]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF__TB_PICKUP__chang__2A164134]  DEFAULT ((0)) FOR [change_banknote100]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF__TB_PICKUP__chang__2B0A656D]  DEFAULT ((0)) FOR [change_banknote500]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF__TB_PICKUP__trans__2BFE89A6]  DEFAULT ('0') FOR [trans_status]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF__TB_PICKUP__ms_ap__2CF2ADDF]  DEFAULT ((0)) FOR [ms_app_step_id]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] ADD  CONSTRAINT [DF__TB_PICKUP__sync___2DE6D218]  DEFAULT ('N') FOR [sync_to_server]
GO
ALTER TABLE [TB_STAFF_CONSOLE_TRANSACTION] ADD  CONSTRAINT [DF__TB_STAFF___creat__0B5CAFEA]  DEFAULT (getdate()) FOR [created_date]
GO
ALTER TABLE [TB_STAFF_CONSOLE_TRANSACTION] ADD  CONSTRAINT [DF__TB_STAFF___login__0C50D423]  DEFAULT ('0') FOR [login_by]
GO
ALTER TABLE [TB_STAFF_CONSOLE_TRANSACTION] ADD  CONSTRAINT [DF__TB_STAFF___sync___0D44F85C]  DEFAULT ('N') FOR [sync_to_server]
GO
ALTER TABLE [MS_DEVICE]  WITH CHECK ADD  CONSTRAINT [FK_MS_DEVIC_REFERENCE_MS_DEVIC2] FOREIGN KEY([ms_device_type_id])
REFERENCES [MS_DEVICE_TYPE] ([id])
GO
ALTER TABLE [MS_DEVICE] CHECK CONSTRAINT [FK_MS_DEVIC_REFERENCE_MS_DEVIC2]
GO
ALTER TABLE [MS_DEVICE_STATUS]  WITH CHECK ADD  CONSTRAINT [FK_MS_DEVIC_REFERENCE_MS_DEVIC] FOREIGN KEY([ms_device_type_id])
REFERENCES [MS_DEVICE_TYPE] ([id])
GO
ALTER TABLE [MS_DEVICE_STATUS] CHECK CONSTRAINT [FK_MS_DEVIC_REFERENCE_MS_DEVIC]
GO
ALTER TABLE [MS_KIOSK_PROMOTION_HOUR]  WITH CHECK ADD  CONSTRAINT [FK_MS_KIOSK_REFERENCE_MS_KIOSK2] FOREIGN KEY([ms_kiosk_promotion_id])
REFERENCES [MS_KIOSK_PROMOTION] ([id])
GO
ALTER TABLE [MS_KIOSK_PROMOTION_HOUR] CHECK CONSTRAINT [FK_MS_KIOSK_REFERENCE_MS_KIOSK2]
GO
ALTER TABLE [MS_LOCKER]  WITH CHECK ADD  CONSTRAINT [FK_MS_LOCKE_REFERENCE_MS_CABIN] FOREIGN KEY([ms_cabinet_id])
REFERENCES [MS_CABINET] ([id])
GO
ALTER TABLE [MS_LOCKER] CHECK CONSTRAINT [FK_MS_LOCKE_REFERENCE_MS_CABIN]
GO
ALTER TABLE [MS_SERVICE_RATE_DEPOSIT]  WITH CHECK ADD  CONSTRAINT [FK_MS_SERVI_REFERENCE_MS_SERVI3] FOREIGN KEY([ms_service_rate_id])
REFERENCES [MS_SERVICE_RATE] ([id])
GO
ALTER TABLE [MS_SERVICE_RATE_DEPOSIT] CHECK CONSTRAINT [FK_MS_SERVI_REFERENCE_MS_SERVI3]
GO
ALTER TABLE [MS_SERVICE_RATE_FINE]  WITH CHECK ADD  CONSTRAINT [FK_MS_SERVI_RE3ERENCE_MS_CABIN] FOREIGN KEY([ms_cabinet_model_id])
REFERENCES [MS_CABINET_MODEL] ([id])
GO
ALTER TABLE [MS_SERVICE_RATE_FINE] CHECK CONSTRAINT [FK_MS_SERVI_RE3ERENCE_MS_CABIN]
GO
ALTER TABLE [MS_SERVICE_RATE_FINE]  WITH CHECK ADD  CONSTRAINT [FK_MS_SERVI_RE3ERENCE_MS_SERVI] FOREIGN KEY([ms_service_rate_id])
REFERENCES [MS_SERVICE_RATE] ([id])
GO
ALTER TABLE [MS_SERVICE_RATE_FINE] CHECK CONSTRAINT [FK_MS_SERVI_RE3ERENCE_MS_SERVI]
GO
ALTER TABLE [MS_SERVICE_RATE_HOUR]  WITH CHECK ADD  CONSTRAINT [FK_MS_SERVI_REFERENCE_MS_SERVI2] FOREIGN KEY([ms_service_rate_id])
REFERENCES [MS_SERVICE_RATE] ([id])
GO
ALTER TABLE [MS_SERVICE_RATE_HOUR] CHECK CONSTRAINT [FK_MS_SERVI_REFERENCE_MS_SERVI2]
GO
ALTER TABLE [MS_SERVICE_RATE_OVERNIGHT]  WITH CHECK ADD  CONSTRAINT [FK_MS_SERVI_REFERENCE_MS_SERVI] FOREIGN KEY([ms_service_rate_id])
REFERENCES [MS_SERVICE_RATE] ([id])
GO
ALTER TABLE [MS_SERVICE_RATE_OVERNIGHT] CHECK CONSTRAINT [FK_MS_SERVI_REFERENCE_MS_SERVI]
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION]  WITH CHECK ADD  CONSTRAINT [FK_TB_SERVI_REFERENCE_MS_LOCKE] FOREIGN KEY([ms_locker_id])
REFERENCES [MS_LOCKER] ([id])
GO
ALTER TABLE [TB_DEPOSIT_TRANSACTION] CHECK CONSTRAINT [FK_TB_SERVI_REFERENCE_MS_LOCKE]
GO
ALTER TABLE [TB_PICKUP_TRANSACTION]  WITH CHECK ADD  CONSTRAINT [FK_TB_PICKU_REFERENCE_MS_LOCKE] FOREIGN KEY([ms_locker_id])
REFERENCES [MS_LOCKER] ([id])
GO
ALTER TABLE [TB_PICKUP_TRANSACTION] CHECK CONSTRAINT [FK_TB_PICKU_REFERENCE_MS_LOCKE]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_KIOSK.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG', @level2type=N'COLUMN',@level2name=N'ms_kiosk_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ทำการ Login ด้วย SSO(Y/N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG', @level2type=N'COLUMN',@level2name=N'login_sso'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เปิดทำการ 24 ชั่วโมง (Y/N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG', @level2type=N'COLUMN',@level2name=N'kiosk_open24'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ระยะเวลารอก่อนแสดง Screen Saver (วินาที)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG', @level2type=N'COLUMN',@level2name=N'screen_saver_sec'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ระยะเวลา Time Out ในแต่ละหน้าจอ (วินาที)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG', @level2type=N'COLUMN',@level2name=N'time_out_sec'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ระยะเวลาแสดงข้อความ (วินาที)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG', @level2type=N'COLUMN',@level2name=N'show_msg_sec'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เวลาที่ให้เพิ่มสำหรับหน้าจอจ่ายเงิน  (วินาที)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG', @level2type=N'COLUMN',@level2name=N'payment_extend_sec'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'URL ของ Locker Webservice' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG', @level2type=N'COLUMN',@level2name=N'locker_webservice_url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ตำแหน่งของ PC ใน Layout' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG', @level2type=N'COLUMN',@level2name=N'locker_pc_position'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เวลาที่จะให้เครื่องเข้า Sleep Mode ทุกวัน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG', @level2type=N'COLUMN',@level2name=N'sleep_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ระยะเวลาที่เข้า Sleep Mode หน่วยเป็นนาที' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG', @level2type=N'COLUMN',@level2name=N'sleep_duration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เบอร์ติดต่อสำหรับพิมพ์ใน Slip' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG', @level2type=N'COLUMN',@level2name=N'contact_center_telno'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'URL ของ Alarm Webservice' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG', @level2type=N'COLUMN',@level2name=N'alarm_webservice_url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รอบเวลาสำหรับการซิงค์ Transaction (นาที)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG', @level2type=N'COLUMN',@level2name=N'interval_sync_transaction_min'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รอบเวลาสำหรับการซิงค์ Master (นาที)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG', @level2type=N'COLUMN',@level2name=N'interval_sync_master_min'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รอบเวลาสำหรับการซิงค์ Log (นาที)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG', @level2type=N'COLUMN',@level2name=N'interval_sync_log_min'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะการ Sync ข้อมูลไปยัง Kiosk(Y/N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG', @level2type=N'COLUMN',@level2name=N'sync_to_kiosk'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะการ Sync ข้อมูลไปยัง Server(Y/N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG', @level2type=N'COLUMN',@level2name=N'sync_to_server'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลการ Config ที่ใช้สำหรับ Kiosk' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CF_KIOSK_SYSCONFIG'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_APP_SCREEN', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_APP_SCREEN', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_APP_SCREEN', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_APP_SCREEN', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_APP_SCREEN', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อหน้าจอ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_APP_SCREEN', @level2type=N'COLUMN',@level2name=N'screen_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อฟอร์ม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_APP_SCREEN', @level2type=N'COLUMN',@level2name=N'form_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลหน้าจอของ Application' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_APP_SCREEN'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_APP_STEP', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_APP_STEP', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_APP_STEP', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_APP_STEP', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_APP_STEP', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code ของ Setp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_APP_STEP', @level2type=N'COLUMN',@level2name=N'app_step_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_APP_SCREEN.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_APP_STEP', @level2type=N'COLUMN',@level2name=N'ms_app_screen_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อ Step ภาษาไทย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_APP_STEP', @level2type=N'COLUMN',@level2name=N'step_name_th'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อ Step ภาษาอังกฤษ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_APP_STEP', @level2type=N'COLUMN',@level2name=N'step_name_en'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลขั้นตอนการทำงานของโปรแกรม' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_APP_STEP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_KIOSK.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET', @level2type=N'COLUMN',@level2name=N'ms_kiosk_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิงรุ่นจาก MS_CABINET_MODEL.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET', @level2type=N'COLUMN',@level2name=N'ms_cabinet_model_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสตู้' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET', @level2type=N'COLUMN',@level2name=N'cabinet_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ตำแหน่งของตู้ใน Layout' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET', @level2type=N'COLUMN',@level2name=N'order_layout'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัตราค่าบริการรายชั่วโมง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET', @level2type=N'COLUMN',@level2name=N'service_rate_hour'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัตราค่าบริการสูงสุดต่อวัน (กรณีรายชั่วโมง)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET', @level2type=N'COLUMN',@level2name=N'service_rate_limit_day'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เงินค่ามัดจำ กรณีเลือกเป็นรายชั่วโมง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET', @level2type=N'COLUMN',@level2name=N'deposit_amt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะการใช้งาน (Y/N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET', @level2type=N'COLUMN',@level2name=N'active_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_CABINET.id ของ Server' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET', @level2type=N'COLUMN',@level2name=N'ms_cabinet_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะการ Sync ข้อมูลไปยัง Kiosk(Y/N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET', @level2type=N'COLUMN',@level2name=N'sync_to_kiosk'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะการ Sync ข้อมูลไปยัง Server(Y/N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET', @level2type=N'COLUMN',@level2name=N'sync_to_server'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูล ตู้ที่ใช้เก็บช่องในของ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET_MODEL', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET_MODEL', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET_MODEL', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET_MODEL', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET_MODEL', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อ Model' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET_MODEL', @level2type=N'COLUMN',@level2name=N'model_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ความกว้างตู้' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET_MODEL', @level2type=N'COLUMN',@level2name=N'cabinet_width'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ความสูงตู้' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET_MODEL', @level2type=N'COLUMN',@level2name=N'cabinet_hight'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ความลึกตู้' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET_MODEL', @level2type=N'COLUMN',@level2name=N'cabinet_deep'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ความกว้างของพื้นที่เก็บสัมภาระ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET_MODEL', @level2type=N'COLUMN',@level2name=N'locker_width'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ความสูงของพื้นที่เก็บสัมภาระ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET_MODEL', @level2type=N'COLUMN',@level2name=N'locker_hight'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ความลึกของพื้นที่เก็บสัมภาระ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET_MODEL', @level2type=N'COLUMN',@level2name=N'locker_deep'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัตราค่าบริการรายชั่วโมง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET_MODEL', @level2type=N'COLUMN',@level2name=N'service_rate_hour'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัตราค่าบริการสูงสุดต่อวัน (กรณีรายชั่วโมง)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET_MODEL', @level2type=N'COLUMN',@level2name=N'service_rate_limit_day'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เงินค่ามัดจำ กรณีเลือกเป็นรายชั่วโมง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET_MODEL', @level2type=N'COLUMN',@level2name=N'deposit_amt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนช่องฝากของ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET_MODEL', @level2type=N'COLUMN',@level2name=N'locker_qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะการใช้งาน(Y/N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET_MODEL', @level2type=N'COLUMN',@level2name=N'active_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูล Cabinet Model' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_CABINET_MODEL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่ออุปกรณ์ภาษาไทย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE', @level2type=N'COLUMN',@level2name=N'device_name_th'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่ออุปกรณ์ภาษาอังกฤษ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE', @level2type=N'COLUMN',@level2name=N'device_name_en'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_DEVICE_TYPE.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE', @level2type=N'COLUMN',@level2name=N'ms_device_type_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'มูลค่าของเงิน (ใช้สำหรับอุปกรณ์รับทอนเงิน)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE', @level2type=N'COLUMN',@level2name=N'unit_value'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนที่เก็บได้สูงสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE', @level2type=N'COLUMN',@level2name=N'max_qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนที่ให้แจ้งเตือน Notification' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE', @level2type=N'COLUMN',@level2name=N'warning_qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนที่ให้แจ้งเตือน Alarm และหยุดการทำงาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE', @level2type=N'COLUMN',@level2name=N'critical_qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รูปภาพ Icon สีขาว' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE', @level2type=N'COLUMN',@level2name=N'icon_white'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รูปภาพ Icon สีเขียว' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE', @level2type=N'COLUMN',@level2name=N'icon_green'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รูปภาพ Icon สีแดง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE', @level2type=N'COLUMN',@level2name=N'icon_red'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'การเรียงลำดับ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE', @level2type=N'COLUMN',@level2name=N'device_order'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะการใช้งาน (Y/N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE', @level2type=N'COLUMN',@level2name=N'active_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลอุปกรณ์' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE_STATUS', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE_STATUS', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE_STATUS', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE_STATUS', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE_STATUS', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อสถานะ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE_STATUS', @level2type=N'COLUMN',@level2name=N'status_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เป็นสถานะที่เกิดปัญหา' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE_STATUS', @level2type=N'COLUMN',@level2name=N'is_problem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_DEVICE_TYPE.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE_STATUS', @level2type=N'COLUMN',@level2name=N'ms_device_type_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลสถานะของอุปกรณ์' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE_STATUS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE_TYPE', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE_TYPE', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE_TYPE', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE_TYPE', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE_TYPE', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่ออุปกรณ์ภาษาไทย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE_TYPE', @level2type=N'COLUMN',@level2name=N'device_type_name_th'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่ออุปกรณ์ภาษาอังกฤษ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE_TYPE', @level2type=N'COLUMN',@level2name=N'device_type_name_en'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Direction ของการรับจ่าย
   1=รับ
   -1=จ่าย
   0=ไม่ระบุ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE_TYPE', @level2type=N'COLUMN',@level2name=N'movement_direction'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะการใช้งาน (Y/N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE_TYPE', @level2type=N'COLUMN',@level2name=N'active_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลประเภทอุปกรณ์' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_DEVICE_TYPE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_ALARM', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_ALARM', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_ALARM', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_ALARM', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_ALARM', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_KIOSK.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_ALARM', @level2type=N'COLUMN',@level2name=N'ms_kiosk_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสของปัญหา อ้างอิงจาก MS_MASTER_MONITORING_ALARM.alarm_problem' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_ALARM', @level2type=N'COLUMN',@level2name=N'alarm_problem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เป็นสถานะ Alarm หรือไม่ (Y/N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_ALARM', @level2type=N'COLUMN',@level2name=N'is_alarm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ส่งสถานะ Alarm ไปยัง Server แล้วหรือไม่ (Y/N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_ALARM', @level2type=N'COLUMN',@level2name=N'is_send_alarm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันเวลาที่ส่งสถานะ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_ALARM', @level2type=N'COLUMN',@level2name=N'last_send_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลการส่ง Status Alarm ของ Kiosk' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_ALARM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_DEVICE', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_DEVICE', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_DEVICE', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_DEVICE', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_DEVICE', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_KIOSK.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_DEVICE', @level2type=N'COLUMN',@level2name=N'ms_kiosk_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_DEVICE.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_DEVICE', @level2type=N'COLUMN',@level2name=N'ms_device_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนที่เก็บได้สูงสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_DEVICE', @level2type=N'COLUMN',@level2name=N'max_qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนที่แจ้งเตือน Notification' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_DEVICE', @level2type=N'COLUMN',@level2name=N'warning_qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนที่แจ้งเตือน Alarm และหยุดการทำงาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_DEVICE', @level2type=N'COLUMN',@level2name=N'critical_qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนคงเหลือปัจจุบัน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_DEVICE', @level2type=N'COLUMN',@level2name=N'current_qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'มูลค่าของเงินที่อยู่ในเครื่อง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_DEVICE', @level2type=N'COLUMN',@level2name=N'current_money'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะการทำงานปัจจุบัน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_DEVICE', @level2type=N'COLUMN',@level2name=N'ms_device_status_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'VID ของ COM PORT ที่ใช้' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_DEVICE', @level2type=N'COLUMN',@level2name=N'comport_vid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะของการ Sync ข้อมูลไปยัง Kiosk (Y/N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_DEVICE', @level2type=N'COLUMN',@level2name=N'sync_to_kiosk'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะของการ Sync ข้อมูลไปยัง Server (Y/N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_DEVICE', @level2type=N'COLUMN',@level2name=N'sync_to_server'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลอุปกรณ์ของ Kiosk' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_DEVICE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_PROMOTION', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_PROMOTION', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_PROMOTION', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_PROMOTION', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_PROMOTION', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_KIOSK.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_PROMOTION', @level2type=N'COLUMN',@level2name=N'ms_kiosk_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสโปรโมชั่น' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_PROMOTION', @level2type=N'COLUMN',@level2name=N'promotion_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อโปรโมชั่น' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_PROMOTION', @level2type=N'COLUMN',@level2name=N'promotion_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่เริ่มใช้' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_PROMOTION', @level2type=N'COLUMN',@level2name=N'start_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สิ้นสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_PROMOTION', @level2type=N'COLUMN',@level2name=N'end_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะการใช้งาน
   0=Inprogress
   1=Active
   2=Expired' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_PROMOTION', @level2type=N'COLUMN',@level2name=N'publish_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูล Promotion ปัจจุบันในการคิดค่าบริการสำหรับแต่ละตู้' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_PROMOTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_PROMOTION_HOUR', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_PROMOTION_HOUR', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_PROMOTION_HOUR', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_PROMOTION_HOUR', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_PROMOTION_HOUR', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_KIOSK_PROMOTION.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_PROMOTION_HOUR', @level2type=N'COLUMN',@level2name=N'ms_kiosk_promotion_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_CABINET_MODEL.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_PROMOTION_HOUR', @level2type=N'COLUMN',@level2name=N'ms_cabinet_model_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชั่วโมงที่' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_PROMOTION_HOUR', @level2type=N'COLUMN',@level2name=N'promotion_hour'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัตราค่าบริการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_PROMOTION_HOUR', @level2type=N'COLUMN',@level2name=N'service_rate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลรายละเอียดการกำหนดราคาค่าบริการตาม Promotion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_KIOSK_PROMOTION_HOUR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_LOCKER', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_LOCKER', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_LOCKER', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_LOCKER', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_LOCKER', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อของตู้ Locker' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_LOCKER', @level2type=N'COLUMN',@level2name=N'locker_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อของตู้บน Layout' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_LOCKER', @level2type=N'COLUMN',@level2name=N'layout_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_KIOSK.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_LOCKER', @level2type=N'COLUMN',@level2name=N'ms_kiosk_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_CABINET.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_LOCKER', @level2type=N'COLUMN',@level2name=N'ms_cabinet_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ขนาด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_LOCKER', @level2type=N'COLUMN',@level2name=N'model_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Pin ที่ใช้ควบคุม Solenoid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_LOCKER', @level2type=N'COLUMN',@level2name=N'pin_solenoid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Pin ที่ใช้ควบคุม LED' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_LOCKER', @level2type=N'COLUMN',@level2name=N'pin_led'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Pin ที่ใช้ควบคุม Sensor' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_LOCKER', @level2type=N'COLUMN',@level2name=N'pin_sensor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะการเปิด/ปิด (O/C)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_LOCKER', @level2type=N'COLUMN',@level2name=N'open_close_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะว่างหรือไม่ว่าง (Y/N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_LOCKER', @level2type=N'COLUMN',@level2name=N'current_available'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะการใช้งาน (Y/N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_LOCKER', @level2type=N'COLUMN',@level2name=N'active_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง Server MS_LOCKER.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_LOCKER', @level2type=N'COLUMN',@level2name=N'ms_locker_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะการ Sync ข้อมูลนี้ไปยัง Server' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_LOCKER', @level2type=N'COLUMN',@level2name=N'sync_to_server'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลตู้ Locker' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_LOCKER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_MASTER_MONITORING_ALARM', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_MASTER_MONITORING_ALARM', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_MASTER_MONITORING_ALARM', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_MASTER_MONITORING_ALARM', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_MASTER_MONITORING_ALARM', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_MASTER_MONITORING_TYPE.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_MASTER_MONITORING_ALARM', @level2type=N'COLUMN',@level2name=N'ms_master_monitoring_type_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสของ Alarm' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_MASTER_MONITORING_ALARM', @level2type=N'COLUMN',@level2name=N'alarm_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสปัญหาที่เกิดขึ้น' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_MASTER_MONITORING_ALARM', @level2type=N'COLUMN',@level2name=N'alarm_problem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รายละเอียดปัญหา ภาษาอังกฤษ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_MASTER_MONITORING_ALARM', @level2type=N'COLUMN',@level2name=N'eng_desc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รายละเอียดปัญหา ภาษาไทย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_MASTER_MONITORING_ALARM', @level2type=N'COLUMN',@level2name=N'tha_desc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อความแจ้งปัญหาทาง SMS' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_MASTER_MONITORING_ALARM', @level2type=N'COLUMN',@level2name=N'sms_message'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูล Master ข้อมูลการ Alarm' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_MASTER_MONITORING_ALARM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_LOCATION.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE', @level2type=N'COLUMN',@level2name=N'ms_kiosk_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลอัตราการคิดค่าบริการสำหรับแต่ละสาขา' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_DEPOSIT', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_DEPOSIT', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_DEPOSIT', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_DEPOSIT', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_DEPOSIT', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_SERVICE_RATE.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_DEPOSIT', @level2type=N'COLUMN',@level2name=N'ms_service_rate_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_CABINET_MODEL.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_DEPOSIT', @level2type=N'COLUMN',@level2name=N'ms_cabinet_model_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเงินค่ามัดจำ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_DEPOSIT', @level2type=N'COLUMN',@level2name=N'deposit_rate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลค่ามัดจำในการใช้บริการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_DEPOSIT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_FINE', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_FINE', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_FINE', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_FINE', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_FINE', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_SERVICE_RATE.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_FINE', @level2type=N'COLUMN',@level2name=N'ms_service_rate_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_CABINET_MODEL.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_FINE', @level2type=N'COLUMN',@level2name=N'ms_cabinet_model_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัตราค่าปรับ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_FINE', @level2type=N'COLUMN',@level2name=N'fine_rate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลค่าปรับกรณีลูกค้าลืม QR Code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_FINE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_HOUR', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_HOUR', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_HOUR', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_HOUR', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_HOUR', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_SERVICE_RATE.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_HOUR', @level2type=N'COLUMN',@level2name=N'ms_service_rate_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_CABINET_MODEL.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_HOUR', @level2type=N'COLUMN',@level2name=N'ms_cabinet_model_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'การฝากในชั่วโมงที่' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_HOUR', @level2type=N'COLUMN',@level2name=N'service_hour'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัตราค่าบริการในแต่ละชั่วโมง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_HOUR', @level2type=N'COLUMN',@level2name=N'service_rate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลอัตราการคิดค่าบริการรายชั่วโมงสำหรับการฝากวันแรก' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_HOUR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_OVERNIGHT', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_OVERNIGHT', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_OVERNIGHT', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_OVERNIGHT', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_OVERNIGHT', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_SERVICE_RATE.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_OVERNIGHT', @level2type=N'COLUMN',@level2name=N'ms_service_rate_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_CABINET_MODEL.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_OVERNIGHT', @level2type=N'COLUMN',@level2name=N'ms_cabinet_model_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ค่าบริการรายวัน กรณีฝากวันที่ 2 เป็นต้นไป' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_OVERNIGHT', @level2type=N'COLUMN',@level2name=N'service_rate_day'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลอัตราค่าบริการกรณีฝากข้ามวัน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MS_SERVICE_RATE_OVERNIGHT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เลขที่ Transaction AutoGen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'trans_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันเวลาที่เริ่ม Transaction' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'trans_start_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันเวลาที่จบ Transaction' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'trans_end_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_LOCKER.id ที่เลือก' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'ms_locker_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ภาพถ่ายจากหนังสือเดินทางหรือบัตรประชาชน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'cust_image'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัตราค่าบริการ ต่อ payment_type' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'service_rate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อัตราค่าบริการสูงสุดต่อวัน (กรณีรายชั่วโมง)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'service_rate_limit_day'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเงินมัดจำ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'deposit_amt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เวลาที่ชำระเงินเสร็จ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'paid_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญบาทที่รับ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'receive_coin1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญ 2 บาทที่รับ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'receive_coin2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญ 5 บาทที่รับ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'receive_coin5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญ 10 บาทที่รับ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'receive_coin10'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนแบงค์ 20 ที่รับ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'receive_banknote20'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนแบงค์ 50 ที่รับ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'receive_banknote50'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนแบงค์ 100 ที่รับ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'receive_banknote100'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนแบงค์ 500 ที่รับ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'receive_banknote500'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนแบงค์ 1000 ที่รับ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'receive_banknote1000'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญบาทที่ทอน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'change_coin1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญ 2 ที่ทอน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'change_coin2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญ 5 ที่ทอน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'change_coin5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญ 10 ที่ทอน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'change_coin10'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนแบงค์ 20 ที่ทอน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'change_banknote20'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนแบงค์ 50 ที่ทอน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'change_banknote50'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนแบงค์ 100 ที่ทอน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'change_banknote100'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนแบงค์ 500 ที่ทอน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'change_banknote500'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Inprogress = 0
   Success = 1
   Cancel = 2
   Problem = 3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'trans_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_APP_SCREEN_.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'ms_app_screen_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Step การทำงานล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'ms_app_step_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะการ Sync ข้อมูลนี้ไปยัง Server' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION', @level2type=N'COLUMN',@level2name=N'sync_to_server'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูล Transaction การทำงานรายการใช้งานตู้ Locker' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_DEPOSIT_TRANSACTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_KIOSK.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'ms_kiosk_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเงินในเครื่องรับเหรียญ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'coin_money'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเงินในเครื่องรับธนบัตร' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'banknote_money'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'มีการคลิกปุ่ม นำออกทั้งหมด (Y/N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'checkout_receive_money'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วัน เวลาที่คลิกปุ่ม นำออกทั้งหมด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'checkout_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญ 1 บาทคงเหลือ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'change1_remain'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญ 2 บาทคงเหลือ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'change2_remain'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญ 5 บาทคงเหลือ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'change5_remain'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญ 10 บาทคงเหลือ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'change10_remain'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนธนบัตร 20 บาทคงเหลือ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'change20_remain'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนธนบัตร 50 บาทคงเหลือ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'change50_remain'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนธนบัตร 100 บาทคงเหลือ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'change100_remain'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนธนบัตร 500 บาทคงเหลือ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'change500_remain'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'มีการคลิกปุ่ม เติมเต็มจำนวน (Y/N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'checkin_change_money'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันเวลาที่คลิกปุ่ม เติมเต็มจำนวน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'checkin_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเงินทั้งหมดเมื่อเข้าหน้าจอ (เงินรับ + เงินทอน)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'total_money_remain'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'คลิกปุ่มยืนยันหรือไม่ (Y/N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'is_confirm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันเวลาที่คลิกปุ่มยืนยัน หรือ ยกเลิก' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'confirm_cancel_datetime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญ 1 บาท เมื่อยืนยัน หรือ ยกเลิก' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'change1_qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญ 2 บาท เมื่อยืนยัน หรือ ยกเลิก' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'change2_qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญ 5 บาท เมื่อยืนยัน หรือ ยกเลิก' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'change5_qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญ 10 บาท เมื่อยืนยัน หรือ ยกเลิก' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'change10_qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนธนบัตร 20 บาท เมื่อยืนยัน หรือ ยกเลิก' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'change20_qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนธนบัตร 50 บาท เมื่อยืนยัน หรือ ยกเลิก' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'change50_qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนธนบัตร 100 บาท เมื่อยืนยัน หรือ ยกเลิก' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'change100_qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนธนบัตร 500 บาท เมื่อยืนยัน หรือ ยกเลิก' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'change500_qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะการ Sync ข้อมูลนี้ไปยัง Server(Y/N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY', @level2type=N'COLUMN',@level2name=N'sync_to_server'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลประวัติการเติมเงินใน Stock' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_FILL_MONEY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_ERROR', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_ERROR', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_ERROR', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_ERROR', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_ERROR', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_KIOSK.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_ERROR', @level2type=N'COLUMN',@level2name=N'ms_kiosk_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อ Class ที่เกิด Error' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_ERROR', @level2type=N'COLUMN',@level2name=N'class_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อ Function ที่เกิด Error' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_ERROR', @level2type=N'COLUMN',@level2name=N'function_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันเวลาที่เกิด Log' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_ERROR', @level2type=N'COLUMN',@level2name=N'error_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รายละเอียด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_ERROR', @level2type=N'COLUMN',@level2name=N'error_desc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง TB_SERVICE_TRANSACTION.trans_no กรณีเกิดปัญหาระหว่าง Service Transaction' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_ERROR', @level2type=N'COLUMN',@level2name=N'deposit_trans_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง TB_PICKUP_TRANSACTION.transaction_no กรณีเกิดปัญหาระหว่าง Pickup Transaction' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_ERROR', @level2type=N'COLUMN',@level2name=N'pickup_trans_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง TB_STAFF_CONSOLE_TRANSACTION.trans_no กรณีเกิดปัญหาระหว่าง Staff Console Transaction' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_ERROR', @level2type=N'COLUMN',@level2name=N'staff_console_trans_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_APP_SCREEN.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_ERROR', @level2type=N'COLUMN',@level2name=N'ms_app_screen_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_APP_STEP.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_ERROR', @level2type=N'COLUMN',@level2name=N'ms_app_step_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะการ Sync ข้อมูลนี้ไปยัง Server' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_ERROR', @level2type=N'COLUMN',@level2name=N'sync_to_server'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูล Log Error' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_ERROR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_KIOSK_AGENT', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_KIOSK_AGENT', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_KIOSK_AGENT', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_KIOSK_AGENT', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_KIOSK_AGENT', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_KIOSK.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_KIOSK_AGENT', @level2type=N'COLUMN',@level2name=N'ms_kiosk_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ประเภท
   1=TransLog
   2=ErrorLog
   3=ExceptionLog' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_KIOSK_AGENT', @level2type=N'COLUMN',@level2name=N'log_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อความ Log' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_KIOSK_AGENT', @level2type=N'COLUMN',@level2name=N'log_message'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อ Class ที่เรียกใช้' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_KIOSK_AGENT', @level2type=N'COLUMN',@level2name=N'class_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ขื่อ Function ที่เรียกใช้' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_KIOSK_AGENT', @level2type=N'COLUMN',@level2name=N'function_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'บรรทัดที่เรียกใช้คำสั่งบันทึก Log' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_KIOSK_AGENT', @level2type=N'COLUMN',@level2name=N'line_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะการ sync ข้อมูลนี้ไปยัง Server' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_KIOSK_AGENT', @level2type=N'COLUMN',@level2name=N'sync_to_server'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลของ Agent Log' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_KIOSK_AGENT'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_TRANSACTION_ACTIVITY', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_TRANSACTION_ACTIVITY', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_TRANSACTION_ACTIVITY', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_TRANSACTION_ACTIVITY', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_TRANSACTION_ACTIVITY', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_KIOSK.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_TRANSACTION_ACTIVITY', @level2type=N'COLUMN',@level2name=N'ms_kiosk_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันเวลาที่เกิด Transaction' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_TRANSACTION_ACTIVITY', @level2type=N'COLUMN',@level2name=N'trans_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง TB_SERVICE_TRANSACTION.trans_no กรณีเกิดปัญหาระหว่าง Service Transaction' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_TRANSACTION_ACTIVITY', @level2type=N'COLUMN',@level2name=N'deposit_trans_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง TB_PICKUP_TRANSACTION.transaction_no กรณีเกิดปัญหาระหว่าง Pickup Transaction' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_TRANSACTION_ACTIVITY', @level2type=N'COLUMN',@level2name=N'pickup_trans_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง TB_STAFF_CONSOLE_TRANSACTION.trans_no กรณีเกิดปัญหาระหว่าง Staff Console Transaction' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_TRANSACTION_ACTIVITY', @level2type=N'COLUMN',@level2name=N'staff_console_trans_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_APP_SCREEN_.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_TRANSACTION_ACTIVITY', @level2type=N'COLUMN',@level2name=N'ms_app_screen_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_APP_STEP.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_TRANSACTION_ACTIVITY', @level2type=N'COLUMN',@level2name=N'ms_app_step_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รายละเอียด Log' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_TRANSACTION_ACTIVITY', @level2type=N'COLUMN',@level2name=N'log_desc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เกิดปัญหา (Y/N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_TRANSACTION_ACTIVITY', @level2type=N'COLUMN',@level2name=N'is_problem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะการ Sync ข้อมูลนี้ไปยัง Server' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_TRANSACTION_ACTIVITY', @level2type=N'COLUMN',@level2name=N'sync_to_server'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูล Log ของการใช้งาน Application' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_LOG_TRANSACTION_ACTIVITY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เลขที่ Transaction AutoGen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'transaction_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันเวลาที่เริ่ม (ตอน Scan QR Code)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'trans_start_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันเวลาที่จบ (ตอนลูกค้าปิดตู้)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'trans_end_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_KIOSK.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'ms_kiosk_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_LOCKER.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'ms_locker_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง TB_SERVICE_TRANSACTION.trans_no' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'deposit_trans_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เป็นการรับคืนเนื่องจาก QR Code หาย
Y=ใช่
N=ไม่ใช่
Z=Null ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'lost_qr_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ค่าบริการทั้งหมด ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'service_amt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เวลาที่รับของ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'pickup_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เวลาที่ชำระค่าบริการสำเร็จ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'paid_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญบาทที่รับ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'receive_coin1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญ 2 บาทที่รับ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'receive_coin2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญ 5 บาทที่รับ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'receive_coin5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญ 10 บาทที่รับ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'receive_coin10'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนแบงค์ 20 ที่รับ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'receive_banknote20'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนแบงค์ 50 ที่รับ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'receive_banknote50'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนแบงค์ 100 ที่รับ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'receive_banknote100'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนแบงค์ 500 ที่รับ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'receive_banknote500'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนแบงค์ 1000 ที่รับ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'receive_banknote1000'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญบาทที่ทอน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'change_coin1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญ 2 ที่ทอน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'change_coin2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญ 5 ที่ทอน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'change_coin5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนเหรียญ 10 ที่ทอน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'change_coin10'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนแบงค์ 20 ที่ทอน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'change_banknote20'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนแบงค์ 50 ที่ทอน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'change_banknote50'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนแบงค์ 100 ที่ทอน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'change_banknote100'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จำนวนแบงค์ 500 ที่ทอน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'change_banknote500'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Inprogress = 0
   Success = 1
   Cancel = 2
   Problem = 3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'trans_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_APP_SCREEN_.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'ms_app_screen_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Step การทำงานล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'ms_app_step_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะการ Sync ข้อมูลนี้ไปยัง Server' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION', @level2type=N'COLUMN',@level2name=N'sync_to_server'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูล Transaction ของการมาเปิดตู้เพื่อรับของ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_PICKUP_TRANSACTION'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'primary key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_STAFF_CONSOLE_TRANSACTION', @level2type=N'COLUMN',@level2name=N'id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_STAFF_CONSOLE_TRANSACTION', @level2type=N'COLUMN',@level2name=N'created_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่สร้างรายการ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_STAFF_CONSOLE_TRANSACTION', @level2type=N'COLUMN',@level2name=N'created_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ผู้แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_STAFF_CONSOLE_TRANSACTION', @level2type=N'COLUMN',@level2name=N'updated_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่แก้ไขล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_STAFF_CONSOLE_TRANSACTION', @level2type=N'COLUMN',@level2name=N'updated_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัส Transaction กรณี Staff Console' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_STAFF_CONSOLE_TRANSACTION', @level2type=N'COLUMN',@level2name=N'trans_no'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันเวลาที่เริ่ม Transaction' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_STAFF_CONSOLE_TRANSACTION', @level2type=N'COLUMN',@level2name=N'trans_start_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันเวลาที่สิ้นสุด Transaction' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_STAFF_CONSOLE_TRANSACTION', @level2type=N'COLUMN',@level2name=N'trans_end_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อ้างอิง MS_KIOSK.id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_STAFF_CONSOLE_TRANSACTION', @level2type=N'COLUMN',@level2name=N'ms_kiosk_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อเข้าระบบที่ Login' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_STAFF_CONSOLE_TRANSACTION', @level2type=N'COLUMN',@level2name=N'login_username'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อคนที่ Login' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_STAFF_CONSOLE_TRANSACTION', @level2type=N'COLUMN',@level2name=N'login_first_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'นามสกุลคนที่ Login' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_STAFF_CONSOLE_TRANSACTION', @level2type=N'COLUMN',@level2name=N'login_last_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อบริษัทของคนที่ Login' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_STAFF_CONSOLE_TRANSACTION', @level2type=N'COLUMN',@level2name=N'login_company_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Login โดย
   1=SSO
   2=Window Authen
   0=ไม่ระบุ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_STAFF_CONSOLE_TRANSACTION', @level2type=N'COLUMN',@level2name=N'login_by'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Step การทำงานล่าสุด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_STAFF_CONSOLE_TRANSACTION', @level2type=N'COLUMN',@level2name=N'ms_app_step_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะการ Sync ข้อมูลนี้ไปยัง Server (Y/N)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_STAFF_CONSOLE_TRANSACTION', @level2type=N'COLUMN',@level2name=N'sync_to_server'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ข้อมูลประวัติการเข้าหน้าจอ Staff Console' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TB_STAFF_CONSOLE_TRANSACTION'
GO
