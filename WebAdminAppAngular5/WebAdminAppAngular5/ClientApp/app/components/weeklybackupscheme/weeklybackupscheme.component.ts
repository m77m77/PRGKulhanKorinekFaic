import { Component, Renderer } from '@angular/core';

@Component({
    selector: 'weeklybackupscheme',
    templateUrl: './weeklybackupscheme.component.html',
    styleUrls: ['./weeklybackupscheme.component.css']

})

export class WeeklybackupScheme {
    constructor(private position: InsertPosition) { }

    public OpenPanel(button: string) {
        this.position = "afterbegin";
        document.activeElement.insertAdjacentHTML(this.position, '<div class="panel panel-default" >'
                                                               + '<div class="panel-body" ><button id="idbtnplus" (click)="btnAdd()">+</button>'
                                                               + '<button id="idbtnminus" (click)="btnSubstract()">-</button>< /div>'
                                                               + '< /div>')

    }

    public btnAdd() {
    var btn = document.getElementById("btnAddbackup")
    var btnplus = document.getElementById("idbtnplus")
    
}

    public btnSubstract() {
    var btn = document.getElementById("btnAddbackup")
    var btnminus = document.getElementById("idbtnminus")

}
}
