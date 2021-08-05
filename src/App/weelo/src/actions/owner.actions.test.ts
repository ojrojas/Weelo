import { uniqueId } from "lodash";
import { Owner } from "../models/owner.model";
import { store } from "../store/store";
import {
  CreateOwner,
  DeleteOwner,
  ListOwner,
  UpdateOwner,
} from "./owner.actions";

describe("Test actions owner", () => {
    const ownerValid1: Owner = {
      name: "prueba de owner 1",
      address: "ever green",
      birthday: new Date(),
      createOn: new Date(),
      id: uniqueId(),
      photo: "photo1",
      state: true,
      createdBy: uniqueId(),
    } as Owner;

    const ownerValid2: Owner = {
      name: "prueba de owner 2",
      address: "ever red",
      birthday: new Date(),
      createOn: new Date(),
      id: uniqueId(),
      photo: "photo1",
      state: true,
      createdBy: uniqueId(),
    } as Owner;

    let list: Owner[] = [];

    it("Create owner1", () => {
      store.dispatch(CreateOwner(ownerValid1));
      list.push(ownerValid1);
      let state = store.getState().owners;
      expect(state.owner.name).toBe("prueba de owner 1");
    });

    it("Create owner2", () => {
      store.dispatch(CreateOwner(ownerValid2));
      list.push(ownerValid2);
      
      let state = store.getState().owners;
      console.log("address", state.owner)
      expect(state.owner.address).toBe("ever red");
    });

    const newAddres = "NewAddrress";
    const ownerValid3 = ownerValid1;
    ownerValid3.address = newAddres;
   
    it("List action owner", () => {
      store.dispatch(ListOwner(list));
      let state = store.getState().owners;
      expect(state.owners.length).toBe(2);
    });

    it("Update action owner", () => {
      store.dispatch(UpdateOwner(ownerValid3));
      let state = store.getState().owners;
      expect(state.owner.address).toBe(newAddres);
    });

    it("Delete action owner", () => {
      store.dispatch(DeleteOwner(ownerValid3));
      let state = store.getState().owners;
      expect(state.owner).toBe(ownerValid3);
    });
  });
