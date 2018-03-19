function displayData() {
    var div_display = document.getElementById('firstdaemon');
    /* This is your input, but you shoud use another Id for your fields. */
    var textValue = document.getElementById('DaemonName').value;
    
  
    /* Change the inner HTML of your div. */
    div_display.innerHTML = textValue;
  }