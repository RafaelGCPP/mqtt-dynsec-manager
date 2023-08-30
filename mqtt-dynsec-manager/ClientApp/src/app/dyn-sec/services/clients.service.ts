import { Injectable } from '@angular/core';
import { catchError, map, Observable, tap } from 'rxjs';
import { Client, ClientList } from '../model/client';
import { DynSecService } from './dynsec.service';

@Injectable({
    providedIn: 'root'
})
export class ClientsService extends DynSecService {


    private clientsApi = "api/clients";
    private clientsMethod = "/clients";
    private clientMethod = "/client";



    public listClients(): Observable<Client[]> {
        return this.http.get<ClientList>(this.clientsApi + this.clientsMethod)           
            .pipe(
                map((clientList: ClientList) => clientList.clients),
                tap(_ => this.log('listClients returned')),
                catchError(this.handleError<Client[]>('listClients', []))
            );
    }

    public getClient (username: string): Observable<Client> {
        return this.http.get<any>(this.clientsApi + this.clientMethod + "/" + username)
            .pipe(
                map((client: { client: Client }) => client.client),
                tap(_ => this.log('getClient returned')),
                catchError(this.handleError<Client>('getClient'))
            );
    }


}
