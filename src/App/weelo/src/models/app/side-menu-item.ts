export interface SideMenuItem {
    name: string;
    icon: any;
    link: string;
    subMenus?: SideMenuItem[];
}
