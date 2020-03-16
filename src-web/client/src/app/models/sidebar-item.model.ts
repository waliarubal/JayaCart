export class SidebarItem {
    readonly Items: SidebarItem[];
    readonly Label: string;
    Header: string;
    Icon: string;
    RouterLink: string;
    IsCollapsed: boolean;

    constructor(label: string, iconClass?: string) {
        this.Items = [];
        this.Label = label;
        this.Header = label;
        this.Icon = iconClass;
        this.IsCollapsed = true;
    }
}