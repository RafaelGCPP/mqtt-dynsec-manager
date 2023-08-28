import { Component } from '@angular/core';
import { Client } from '../model/client';
import { ClientsService } from '../services/clients.service';



@Component({
    selector: 'app-clients',
    templateUrl: './clients.component.html',
    styleUrls: ['./clients.component.css'],
})
export class ClientsComponent {

    public clients: Client[] = [];
    panelOpenState = false;

    
    constructor(private clientService : ClientsService) { }
    
    ngOnInit() {
        this.clientService.listClients().subscribe(data => this.clients = data);
    }
    
}
