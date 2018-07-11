namespace importer {
  namespace writers {
    interface IWriter {
      void Write (string[][] data, System.IO.StreamWriter file);
    }
  }
}