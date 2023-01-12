using System;

namespace UAS_095
{
    class Node
    {
        /*Node class represents the node of doubly linked list.
          * It consists of the information part and links to
          * its succeeding and preceding nodes
          * in terms of next and previous nodes.*/
        public int rollNumber;
        public string name;
        public Node next;/*points to the succeeding node*/
        public Node prev;/*points to the preceeding node*/
    }
    class DoubleLinkedList
    {
        Node START;
        public DoubleLinkedList()
        {
            START = null;
        }
        public void DataPelanggan()
        {

            int Data = 1;
            string[] Id = new string[Data];
            string[] Name = new string[Data];
            string[] JenisKelamin = new string[Data];

            for (int i = 0; i < Data; i++)
            {
                Console.Write("Masukkan Nama Pelanggan: ");
                Name[i] = Console.ReadLine();
                Console.Write("Masukkan ID Pelanggan: ");
                Id[i] = Console.ReadLine();
                Console.Write("Masukkan Jenis Kelamin Pelanggan: ");
                JenisKelamin[i] = Console.ReadLine();

                Console.WriteLine("");

                Console.WriteLine("Nama\tID\tJenisKelamin");
                Console.WriteLine("");
            }

            for (int i = 0; i < Data; i++)
            {
                Console.WriteLine(Name[i] + "\t" + Id[i] + "\t" + JenisKelamin[i]);
            }
        }
        /*Checks whether the specified node is present*/
        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            for (previous = current = START; current != null &&
                rollNo != current.rollNumber; previous = current,
                current = current.next)
            { }
            /*The above for loop traverses the list. If the specified node
             is found then the function return true, otherwise false.*/
            return (current != null);
        }
        public bool delNode(int rollNo)/*Deletes the specified node*/
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            if (current == START)/*If the first node is to be deleted*/
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }
            if (current.next == null)/*if the last node is to be deleted*/
            {
                previous.next = null;
                return true;
            }
            /*If the node to be deleted is in between the list then the
             following lines of code is executed*/
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        public void traverse()/*Traverses the list*/
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the ascending order of " +
                    "roll numbers are: \n");
                Node currentNode;
                for (currentNode = START; currentNode != null;
                    currentNode = currentNode.next)
                    Console.Write(currentNode.rollNumber + "  "
                        + currentNode.name + "\n");
            }
        }
        public void revtraverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the descending order of " +
                    "roll numbers are: \n");
                Node currentNode;
                for (currentNode = START; currentNode.next != null;
                    currentNode = currentNode.next)
                { }
                while (currentNode != null)
                {
                    Console.Write(currentNode.rollNumber + "  "
                        + currentNode.name + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }

        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            DoubleLinkedList obj = new DoubleLinkedList();
            while (true)
            {
                try
                {
                    Console.Write("\n " +
                        "\n 1. Add Data Pelanggan" +
                        "\n 2. Delete Data" +
                        "\n 3. Tampilkan Data Pelanggan " +
                        "\n 5. Cari Data " +
                        "\n 6. Exit \n" +
                        "\n Silahkan Pilih (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.DataPelanggan();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nData Dihapus");
                                    break;
                                }
                                Console.Write("\nEnter the Data of the Customer" +
                                    " whose record is to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(rollNo) == false)
                                    Console.WriteLine("Record not found");
                                else
                                    Console.WriteLine("Record with roll number " + rollNo + "deleted \n");
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                obj.revtraverse();
                            }
                            break;
                        case '5':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the Data Of The Customer whose record you want to search: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " + curr.rollNumber);
                                    Console.WriteLine("\nName: " + curr.name);
                                }
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Check for the values entered");
                }
            }
        }
    }
}
/*JAWABAN ESSAY*/
/*2. Pada program ini saya menggunakan Double Linked List dan Queue, karena menurut saya ini tepat, Double Linked List dapat mengurutkan data, dibandingkan dengan single , double lebih sesuai
 * dan queue digunakan untuk memasukan dan menghapus data 
/*3. Rear and Front
/*4. linked list merupakan sebuah struktur data yang digunakan untuk menyimpan 
sejumlah objek data biasanya secara terurut sehingga memungkinkan penambahan, 
pengurangan, dan pencarian atas elemen data yang tersimpan dan dilakukan secara lebih efektif.
sedangkan array merupakan data jenis nya berbeda, sehingga akan tersusun secara random atau acak
/*5 a. Node 10 and 30 are siblings, node 5 and 15, node 20 dan 32, node 10 and 15, node 20 and 28
 *  b. Metode Preorder , 20,10,5,15,10,12,15,18,16,30,20,20,25,20,28,32 */
