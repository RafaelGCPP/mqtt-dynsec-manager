import { Component } from '@angular/core';

const data = `
{
    "totalCount": 2,
        "clients": [
            {
                "userName": "admin",
                "textName": "Dynsec admin user",
                "textDescription": null,
                "roles": [
                    {
                        "roleName": "admin"
                    }
                ],
                "groups": []
            },
            {
                "userName": "rafael",
                "textName": "Rafael Pinto",
                "textDescription": "Teste",
                "roles": [],
                "groups": [
                    {
                        "groupName": "teste"
                    }
                ]
            }
        ]
} `

@Component({
    selector: 'app-clients',
    templateUrl: './clients.component.html',
    styleUrls: ['./clients.component.css'],
})
export class ClientsComponent {

    public clients: any[] = JSON.parse(data).clients;
    panelOpenState = false;

    
    constructor() { }
    
    ngOnInit() {
    }
    
}
