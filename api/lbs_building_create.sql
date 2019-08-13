-- Create table
create table LBS_BUILDING
(
  building_id      RAW(16) default sys_guid() not null,
  building_code    NVARCHAR2(200),
  building_name    NVARCHAR2(200),
  building_address NVARCHAR2(2000),
  building_region  NVARCHAR2(200),
  building_type    NVARCHAR2(200),
  building_x       NUMBER,
  building_y       NUMBER,
  building_lng     NUMBER,
  building_lat     NUMBER,
  building_bounds  NVARCHAR2(2000),
  memo            NVARCHAR2(800),
  households      NUMBER,
  is_valid        NUMBER(1) default 1,
  area_id         RAW(16),
  create_date     DATE default sysdate
)
tablespace JJLBSDB
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  )
nologging;
-- Add comments to the table 
comment on table LBS_BUILDING
  is '小区/院/村信息表';
-- Add comments to the columns 
comment on column LBS_BUILDING.building_id
  is '主键';
comment on column LBS_BUILDING.building_code
  is '小区编号';
comment on column LBS_BUILDING.building_name
  is '名称';
comment on column LBS_BUILDING.building_address
  is '详细地址';
comment on column LBS_BUILDING.building_region
  is '所在地区';
comment on column LBS_BUILDING.building_type
  is '类型';
comment on column LBS_BUILDING.building_bounds
  is '小区边界';
comment on column LBS_BUILDING.memo
  is '备注';
comment on column LBS_BUILDING.households
  is '规划户数';
comment on column LBS_BUILDING.is_valid
  is '标识该小区是否有效 1-有效，0-无效';
comment on column LBS_BUILDING.area_id
  is '片区ID';
comment on column LBS_BUILDING.create_date
  is '建立日期';
