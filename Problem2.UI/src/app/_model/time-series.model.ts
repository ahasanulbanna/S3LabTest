import { SelectList } from "./select-list.model";

export class TimeSeries {
    public buildingSelectList: SelectList[];
    public dataFieldSelectList:SelectList[];
    public objectsSelectList:SelectList[];
    constructor(buildingSelectList: SelectList[], dataFieldSelectList: SelectList[],objectsSelectList: SelectList[]) {
        this.buildingSelectList = buildingSelectList;
        this.dataFieldSelectList = dataFieldSelectList;
        this.objectsSelectList = objectsSelectList;
      }
}
