import { Component, Input } from '@angular/core';
import { Client } from '../model/client';
import { ClientsService } from '../services/clients.service';



@Component({
    selector: 'app-client-detail',
    templateUrl: './client-detail.component.html',
    styleUrls: ['./client-detail.component.css']
})
export class ClientDetailComponent {
    @Input() userName: string = '';
    public client: Client = {
        userName: '',
        textName: '',
        textDescription: '',
        roles: [],
        groups: []
    };

    constructor(private clientService: ClientsService) { }

    ngOnInit() {
        this.clientService.getClient(this.userName).subscribe(data => this.client = data);
    }
}
