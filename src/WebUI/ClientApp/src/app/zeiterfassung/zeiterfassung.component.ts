import { Component } from '@angular/core';

@Component({
  selector: 'app-zeiterfassung',
  templateUrl: './zeiterfassung.component.html',
})
export class ZeiterfassungComponent {
  Datum: '15.03.2023';
  gesamt: '01:05';
  bezahlt: '00:45';
  pause: '00:40';
  unbezahlt: '04:30';
}
