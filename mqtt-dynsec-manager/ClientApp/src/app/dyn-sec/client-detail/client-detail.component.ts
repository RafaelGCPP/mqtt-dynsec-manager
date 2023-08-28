import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-client-detail',
  templateUrl: './client-detail.component.html',
  styleUrls: ['./client-detail.component.css']
})
export class ClientDetailComponent {
    @Input() userName: string = '';

}
