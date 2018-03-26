import { Component,Renderer2 } from '@angular/core';

@Component({
    selector: 'dailybackupscheme',
    templateUrl: './dailybackupscheme.component.html',
    styleUrls: ['./dailybackupscheme.component.css']


})
export class DailybackupschemeComponent {
    constructor(private renderer: Renderer2) {

    }

    validate() {
        var backups = <HTMLDivElement>document.getElementById("dailyScheme");

        var elements = backups.querySelectorAll('div.dailyOneBackup');

        var first = null;

        for (var i = 0; i < elements.length; i++) {
            var el = elements[i];
            var timeInput = <HTMLInputElement>el.querySelector('input.time');
            var select = <HTMLSelectElement>el.querySelector('select.backupType');
            select.disabled = false;
            timeInput.parentNode
            if (first == null) {
                first = timeInput;
            } else {
                if (timeInput.value < first.value)
                    first = timeInput;
            }

            console.log(timeInput.value);

        }
        if (first != null) {
            var parent = <HTMLDivElement>first.parentNode;
            if (parent != null) {
                var select = <HTMLSelectElement>parent.querySelector('select.backupType');
                select.selectedIndex = 0;
                select.disabled = true;
            }
                
        }
        //var select = <HTMLSelectElement>first.querySelector('select.backupType');
    }

    addBackup() {
        var backups = <HTMLDivElement>document.getElementById("dailyScheme");

        var newBackup = this.renderer.createElement('div');
        newBackup.className = 'dailyOneBackup';
        //newBackup.innerHTML =
        //    '<input type="time" class="time" value="00:00" required> <br />' +
        //    '<select class="backupType">' +
        //    '<option value="FULL" > Full </option>' +
        //    '<option value= "DIFF"> Differential </option>' +
        //    '<option value= "INC"> Incremental </option>' +
        //    '</select> <br / >';

        var br1 = this.renderer.createElement('br');
        var br2 = this.renderer.createElement('br');

        var input = this.renderer.createElement('input');
        input.type = 'time';
        input.className = 'time';
        input.value = '00:00'
        input.required = true;

        var select = this.renderer.createElement('select');
        select.className = 'backupType';
        select.innerHTML = 
            '<option value="FULL" > Full </option>' +
            '<option value= "DIFF"> Differential </option>' +
            '<option value= "INC"> Incremental </option>';

        var button = this.renderer.createElement('button');
        button.className = 'btnRemove';
        button.innerHTML = '-';
            

        this.renderer.listen(button, 'click', (evn) => this.deleteBackup(evn));
        this.renderer.listen(input, 'change', (evn) => this.validate());
        this.renderer.listen(select, 'change', (evn) => this.validate());

        this.renderer.appendChild(newBackup, input);
        this.renderer.appendChild(newBackup, br1);
        this.renderer.appendChild(newBackup, select);
        this.renderer.appendChild(newBackup, br2);
        this.renderer.appendChild(newBackup, button);


        this.renderer.appendChild(backups, newBackup);

        this.validate();
    }

    deleteBackup(event : any) {
        var target = event.target || event.srcElement || event.currentTarget;

        var backups = <HTMLDivElement>document.getElementById("dailyScheme");

        this.renderer.removeChild(backups, target.parentNode);

        this.validate();
    }
}