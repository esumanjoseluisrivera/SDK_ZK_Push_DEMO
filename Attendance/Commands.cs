using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Attendance
{
    /// <summary>Command Content
    /// </summary>
    class Commands
    {
        //Control
        public const string Command_ControlReboot = "REBOOT";
        public const string Command_ControlUnLock = "AC_UNLOCK";
        public const string Command_ControlUnAlarm = "AC_UNALARM";
        public const string Command_ControlInfo = "INFO";

        //Update
        public const string Command_UpdateUserInfo = "DATA UPDATE USERINFO PIN={0}\tName={1}\tPri={2}\tPasswd={3}\tCard={4}\tGrp={5}\tTZ={6}";
        public const string Command_UpdateIDCard = "";
        public const string Command_UpdateFingerTmp = "DATA UPDATE FINGERTMP PIN={0}\tFID={1}\tSize={2}\tValid={3}\tTMP={4}";
        public const string Command_UpdateFaceTmp = "DATA UPDATE FACE PIN={0}\tFID={1}\tValid={2}\tSize={3}\tTMP={4}";
        public const string Command_UpdateFvein = "DATA$ UPDATE FVEIN Pin={0}\tFID={1}\tIndex={2}\tValid={3}\tSize={4}\tTmp={5}";
        public const string Command_UpdateBioData = "DATA UPDATE BIODATA Pin={0}\tNo={1}\tIndex={2}\tValid={3}\tDuress={4}\tType={5}\tMajorVer={6}\tMinorVer ={7}\tFormat={8}\tTmp={9}";
        public const string Command_UpdateBioPhoto = "DATA UPDATE BIOPHOTO PIN={0}\tType={1}\tSize={2}\tContent={3}\tFormat={4}\tUrl={5}\tPostBackTmpFlag={6}";
        public const string Command_UpdateUserPic = "DATA UPDATE USERPIC PIN={0}\tSize={1}\tContent={2}";
        public const string Command_UpdateSMS = "DATA UPDATE SMS MSG={0}\tTAG={1}\tUID={2}\tMIN={3}\tStartTime={4}";
        public const string Command_UpdateUserSMS = "DATA UPDATE USER_SMS PIN={0}\tUID={1}";
        public const string Command_UpdateAdPic = "DATA UPDATE ADPIC Index={0}\tSize={1}\tExtension={2}\tContent={3}";
        public const string Command_UpdateWorkCode = "DATA UPDATE WORKCODE PIN={0}\tCODE={1}\tNAME={2}";
        public const string Command_UpdateShortcutKey = "DATA UPDATE ShortcutKey KeyID={0}\tKeyFun={1}\tStatusCode=={2}\tShowName={3}\tAutoState={4}\tAutoTime={5}\tSun={6}\tMon={7}\tTue={8}\tWed={9}\tThu={10}\tFri={11}\tSat={12}";
        public const string Command_UpdateAccGroup = "DATA UPDATE AccGroup ID={0}\tVerify={1}\tValidHoliday={2}\tTZ={3}";
        public const string Command_UpdateAccTimeZone = "DATA UPDATE AccTimeZone UID={0}\tSunStart={1}\tSunEnd={2}\tMonStart={3}\tMonEnd={4}\tTuesStart={5}\tTuesEnd={6}\tWedStart={7}\tWedEnd={8}\tThursStart={9}\tThursEnd={10}\tFriStart={11}\tFriEnd={12}\tSatStart={13}\tSatEnd={14}";
        public const string Command_UpdateAccHoliday = "DATA UPDATE AccHoliday UID={0}\tHolidayName={1}\tStartDate={2}\tEndDate={3}\tTimeZone={4}";
        public const string Command_UpdateAccUnLockComb = "DATA UPDATE AccUnLockComb UID={0}\tGroup1={1}\tGroup2={2}\tGroup3={3}\tGroup4={4}\tGroup5={5}";
        public const string Command_UpdateBlackList = "DATA UPDATE Blacklist IDNum={0}";

        //Delete
        public const string Command_DeleteUser = "DATA DELETE USERINFO PIN={0}";
        public const string Command_DeleteFingerTmp1 = "DATA DELETE FINGERTMP PIN={0}";
        public const string Command_DeleteFingerTmp2 = "DATA DELETE FINGERTMP PIN={0}\tFID={1}";
        public const string Command_DeleteFace = "DATA DELETE FACE PIN={0}";
        public const string Command_DeleteFvein1 = "DATA DELETE FVEIN Pin={0}";
        public const string Command_DeleteFvein2 = "DATA DELETE FVEIN Pin={0}\tFID={1}";
        public const string Command_DeleteBioData1 = "DATA DELETE BIODATA Pin={0}";
        public const string Command_DeleteBioData2 = "DATA DELETE BIODATA Pin={0}\tType={1}";
        public const string Command_DeleteBioData3 = "DATA DELETE BIODATA Pin={0}\tType={1}\tNo={2}";
        public const string Command_DeleteUserPic = "DATA DELETE USERPIC PIN={0}";
        public const string Command_DeleteBioPhoto = "DATA DELETE BIOPHOTO PIN={0}";
        public const string Command_DeleteSMS = "DATA DELETE SMS UID={0}";
        public const string Command_DeleteWorkCode = "DATA DELETE WORKCODE CODE={0}";
        public const string Command_DeleteAdPic = "DATA DELETE ADPIC Index={0}";

        //Query
        public const string Command_QueryAttLog = "DATA QUERY ATTLOG StartTime={0}\tEndTime={1}";
        public const string Command_QueryAttPhoto = "DATA QUERY ATTPHOTO StartTime={0}\tEndTime={1}";
        public const string Command_QueryUserInfo = "DATA QUERY USERINFO PIN={0}";
        public const string Command_QueryFingerTmp = "DATA QUERY FINGERTMP PIN={0}\tFID={1}";
        public const string Command_QueryBioData1 = "DATA QUERY BIODATA Type={0}";
        public const string Command_QueryBioData2 = "DATA QUERY BIODATA Type={0}\tPIN={1}";
        public const string Command_QueryBioData3 = "DATA QUERY BIODATA Type={0}\tPIN={1}\tNo={2}";

        //Clear
        public const string Command_ClearLog = "CLEAR LOG";
        public const string Command_ClearPhoto = "CLEAR PHOTO";
        public const string Command_ClearData = "CLEAR DATA";
        public const string Command_ClearBioData = "CLEAR BIODATA";

        //Check
        public const string Command_Check = "CHECK";

        //Set
        public const string Command_SetOption = "SET OPTION {0}={1}";
        public const string Command_SetReloadOptions = "RELOAD OPTIONS";

        //File
        public const string Command_PutFile = "PutFile {0}\t{1}";

        //Enroll
        public const string Command_EnrollFP = "ENROLL_FP PIN={0}\tFID={1}\tRETRY={2}\tOVERWRITE={3}";

        //Other
        public const string Command_Unknown = "UNKNOWN";
    }
}
