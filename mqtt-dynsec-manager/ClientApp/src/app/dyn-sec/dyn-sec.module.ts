import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientsComponent } from './clients/clients.component';
import { RouterModule } from '@angular/router';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { ClientDetailComponent } from './client-detail/client-detail.component';


@NgModule({
    declarations: [
        ClientsComponent,
        ClientDetailComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forChild([
            { path: 'clients', component: ClientsComponent },

        ]),
        MatExpansionModule,
        MatInputModule,
        MatFormFieldModule,
        FormsModule
    ]
})
export class DynSecModule { }
