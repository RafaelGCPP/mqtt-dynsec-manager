import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientsComponent } from './clients/clients.component';
import { RouterModule } from '@angular/router';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';


@NgModule({
    declarations: [
        ClientsComponent
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
