function enableLND()
{
   /* var index;
    var elements = document.getElementByClassName("pathtext");
    var count = elements.length;
    
    for(index = 0; index < count; index++){
        elements[index].disabled = true;
    }*/
    document.getElementById("LNDpath").disabled = false;
    document.getElementById("FTPserver").disabled = true;
    document.getElementById("SFTPserver").disabled = true;
    document.getElementById("FTPport").disabled = true;
    document.getElementById("SFTPport").disabled = true;
    document.getElementById("FTPpassword").disabled = true;
    document.getElementById("SFTPpassword").disabled = true;
    document.getElementById("FTPusername").disabled = true;
    document.getElementById("SFTPusername").disabled = true;
    document.getElementById("FTPpath").disabled = true;
    document.getElementById("SFTPpath").disabled = true;
}

function enableFTP()
{
    document.getElementById("FTPserver").disabled = false;
    document.getElementById("FTPport").disabled = false;
    document.getElementById("FTPpassword").disabled = false;
    document.getElementById("FTPusername").disabled = false;
    document.getElementById("FTPpath").disabled = false;
    document.getElementById("LNDpath").disabled = true;
    document.getElementById("SFTPserver").disabled = true;
    document.getElementById("SFTPpassword").disabled = true;
    document.getElementById("SFTPport").disabled = true;
    document.getElementById("SFTPpath").disabled = true;
    document.getElementById("SFTPusername").disabled = true;

}

function enableSFTP()
{
    document.getElementById("SFTPserver").disabled = false;
    document.getElementById("SFTPpassword").disabled = false;
    document.getElementById("SFTPport").disabled = false;
    document.getElementById("SFTPpath").disabled = false;
    document.getElementById("SFTPusername").disabled = false;
    document.getElementById("FTPserver").disabled = true;
    document.getElementById("FTPport").disabled = true;
    document.getElementById("FTPpassword").disabled = true;
    document.getElementById("FTPusername").disabled = true;
    document.getElementById("FTPpath").disabled = true;
    document.getElementById("LNDpath").disabled = true;
}

function enableMail()
{
    var chkemail = document.getElementById("checkboxmail");

   if(chkemail.checked == true)
   {
    document.getElementById("idemailTo").disabled = false;
    document.getElementById("idemailTemplate").disabled = false;
   }
   else{
    document.getElementById("idemailTo").disabled = true;
    document.getElementById("idemailTemplate").disabled = true;
   }
   
}
