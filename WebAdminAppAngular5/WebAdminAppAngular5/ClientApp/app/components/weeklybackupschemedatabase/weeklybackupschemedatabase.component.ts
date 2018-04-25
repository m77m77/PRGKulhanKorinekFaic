import { Component, ElementRef } from '@angular/core';

@Component({
    selector: 'weeklybackupscheme',
    templateUrl: './weeklybackupscheme.component.html',
    styleUrls: ['./weeklybackupscheme.component.css']

})

export class WeeklybackupScheme {
    constructor(private position: InsertPosition, private elementRef: ElementRef) { }
    
    public OpenPanel(button: string) {
        this.position = "afterbegin";

        var d1 = this.elementRef.nativeElement.querySelector('.one');
        d1.insertAdjacentHTML(this.position, '<div class="panel panel-default" >'
                                           + '<div class="panel-body" ><button id="idbtnplus" (click)="btnAdd()">+</button>'
                                           + '<button id="idbtnminus" (click)="btnSubstract()">-</button>< /div>'
                                           + '< /div>')


        
        //document.activeElement.insertAdjacentHTML(this.position, '<div class="panel panel-default" >'
        //                                                       + '<div class="panel-body" ><button id="idbtnplus" (click)="btnAdd()">+</button>'
        //                                                       + '<button id="idbtnminus" (click)="btnSubstract()">-</button>< /div>'
        //                                                       + '< /div>')

    }

    public btnAdd() {
    var btn = document.getElementById("btnAddbackup")
    var btnplus = document.getElementById("idbtnplus")

    var d1 = this.elementRef.nativeElement.querySelector('.two');
    d1.insertAdjacentHTML(this.position, '<input type="text" name="scheme" list="exampleList">'
                                        +'< datalist id= "exampleList" >'
                                        +'<option value="FULL" >'
                                        +'<option value="INCREMENTAL" >'
                                        +'<option value="DIFFERENCIAL" >'
                                        +'</datalist>')
    
}

    public btnSubstract() {
    var btn = document.getElementById("btnAddbackup")
    var btnminus = document.getElementById("idbtnminus")

    var d1 = this.elementRef.nativeElement.querySelector('.two');
    d1.insertAdjacentHTML(this.position, '')

}
}
