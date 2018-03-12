function check()
{
    var index;
    var elements = document.getElementsByName("INPUT");
    var count = elements.length;
    
    for(index = 0; index < count; index++){
        elements[index].disabled = true;
    }
}

