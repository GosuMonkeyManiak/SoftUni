function factory(library, orders) {

    let reuslt = [];

    for (let i = 0; i < orders.length; i++) {
        
        let {...copiedTemplate} = orders[i].template;

        for (const partName of orders[i].parts) {
            
            if (library[partName] == undefined) {
                continue;
            }

            let part = library[partName];

            copiedTemplate[partName] = part;
        }

        reuslt.push(copiedTemplate);
    }

    return reuslt;
}

const library = {
  print: function () {
    console.log(`${this.name} is printing a page`);
  },
  scan: function () {
    console.log(`${this.name} is scanning a document`);
  },
  play: function (artist, track) {
    console.log(`${this.name} is playing '${track}' by ${artist}`);
  },
};
const orders = [
  {
    template: { name: 'ACME Printer'},
    parts: ['print']      
  },
  {
    template: { name: 'Initech Scanner'},
    parts: ['scan']      
  },
  {
    template: { name: 'ComTron Copier'},
    parts: ['scan', 'print']      
  },
  {
    template: { name: 'BoomBox Stereo'},
    parts: ['play']      
  }
];

const products = factory(library, orders);

console.log(products);
