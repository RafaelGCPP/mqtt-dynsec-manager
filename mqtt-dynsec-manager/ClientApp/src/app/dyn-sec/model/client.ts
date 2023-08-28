export interface ClientList {
    totalCount: number;
    clients: Client[];
}

export interface Client {
    userName: string;
    textName: string;
    textDescription: string;
    roles: RoleName[];
    groups: GroupName[];
}

export interface RoleName {
    roleName: string;
}

export interface GroupName {
    groupName: string;
}
