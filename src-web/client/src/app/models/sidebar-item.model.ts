export class SidebarItem {
    readonly Items: SidebarItem[];
    readonly Label: string;
    Icon: string;
    RouterLink: string;
    IsExpanded: boolean;

    constructor(label: string, iconClass?: string) {
        this.Items = [];
        this.Label = label;
        this.Icon = iconClass;
        this.IsExpanded = false;
    }
}