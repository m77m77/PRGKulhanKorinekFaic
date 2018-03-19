function btnAdd()
{
    var btn = document.getElementById("btnAddbackup")
    //btn.style.zIndex = -1;
    btn.style.left = "880px";
    document.getElementById("idbackuptypes").disabled = true;
    var btnminus = document.getElementById("idbtnminus")
    btnminus.style.zIndex = 1;
}

function btnSubstract()
{
    
    var btn = document.getElementById("btnAddbackup")
    var btnminus = document.getElementById("idbtnminus")
    btnminus.style.zIndex = -1;
    btn.style.zIndex = 1;
    btn.style.left = "760px";
}