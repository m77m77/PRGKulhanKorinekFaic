import { Component, ElementRef } from '@angular/core';

@Component({
    selector: 'weeklybackupschemenew',
    templateUrl: './weeklybackupschemenew.component.html',
    styleUrls: ['./weeklybackupschemenew.component.css']

})
export class WeeklybackupschemenewComponent{
    private position: InsertPosition;
    private elementRef: ElementRef;

    constructor() {
        this.position = 'afterbegin';

    }
    
    
    public OpenPanel(button: string)
    {
        //this.position = "afterbegin";
        
        //var d1 = this.elementRef.nativeElement.querySelector('.one');
        //d1.insertAdjacentHTML(this.position, '<div class="panel panel-default" >'
        //                                   + '<div class="panel-body" ><button id="idbtnplus" (click)="btnAdd()">+</button>'
        //                                   + '<button id="idbtnminus" (click)="btnSubstract()">-</button>< /div>'
        //    + '< /div>')

        (<HTMLInputElement>document.getElementById(button)).innerHTML = '<div class="panel panel-default" >'
                                                                      + '<div class="panel-body" id="panel" ><button id="idbtnplus" (click)="btnAdd()">+</button>'
                                                                    + '<button id="idbtnminus" (click)="btnSubstract()">-</button></div>'
                                                                    +'<div id="content"></div>'
                                                                    + '</div>';

    }

    public btnAdd() {

        //(<HTMLInputElement>document.getElementById('idbtnplus')).innerHTML = '<select>'
        //                                                                    +'<option value="FULL" > FULL </option>'
        //                                                                    +'<option value= "INCREMENTA" > INCREMENTAL </option>'
        //                                                                    +'<option value= "DIFFERENTIAL" > DIFFERENTIAL </option>'
        //                                                                    + '</select>';

        var div = document.createElement('div');
        div.className = 'panel panel-default';
        div.innerHTML = '<select>'
            + '<option value="FULL" > FULL </option>'
            + '<option value= "INCREMENTA" > INCREMENTAL </option>'
            + '<option value= "DIFFERENTIAL" > DIFFERENTIAL </option>'
            + '</select>';

        (<HTMLInputElement>document.getElementById('content')).appendChild(div);


        var p = (<HTMLInputElement>document.getElementById('panel'));
        var newElement = document.createElement('test');
        newElement.setAttribute('id', 'testid');
        newElement.innerHTML = '<select>'
            + '<option value="FULL" > FULL </option>'
            + '<option value= "INCREMENTA" > INCREMENTAL </option>'
            + '<option value= "DIFFERENTIAL" > DIFFERENTIAL </option>'
            + '</select>';

        p.appendChild(newElement);
        
}

    public btnSubstract() {
}
}
