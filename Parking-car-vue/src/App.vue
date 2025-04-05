<template>
  <div class="min-h-screen bg-gradient-to-br from-blue-50 to-gray-100 p-4 md:p-8">
    <div class="max-w-6xl mx-auto bg-white rounded-2xl shadow-xl overflow-hidden">
      <!-- Header Section -->
      <div class="bg-blue-600 px-6 py-4">
        <h1 class="text-2xl md:text-3xl font-bold text-white text-center">ระบบออกบัตรจอดรถ</h1>
      </div>

      <div class="p-6 md:p-8">
        <!-- Form Section -->
        <div class="mb-10">
          <h2 class="text-xl font-semibold mb-6 text-gray-800 border-b pb-2">{{ editMode ? 'แก้ไขบัตรจอดรถ' :
            'ออกบัตรจอดรถใหม่' }}</h2>

          <form @submit.prevent="handleSubmit" class="grid grid-cols-1 md:grid-cols-2 gap-6">
            <!-- Form Inputs -->
            <div class="space-y-2">
              <label class="block text-sm font-medium text-gray-700">ทะเบียนรถ <span
                  class="text-red-500">*</span></label>
              <input v-model="form.plateNumber"
                class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                type="text" placeholder="XX-1234" required />
            </div>

            <div class="space-y-2">
              <label class="block text-sm font-medium text-gray-700">ชื่อคนขับ <span
                  class="text-red-500">*</span></label>
              <input v-model="form.driverName"
                class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                type="text" required />
            </div>

            <div class="space-y-2">
              <label class="block text-sm font-medium text-gray-700">สีรถ <span class="text-red-500">*</span></label>
              <input v-model="form.carColor"
                class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                type="text" required />
            </div>

            <div class="space-y-2">
              <label class="block text-sm font-medium text-gray-700">ประเภทรถ <span
                  class="text-red-500">*</span></label>
              <select v-model="form.carType"
                class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                required>
                <option value="" disabled selected>เลือกประเภทรถ</option>
                <option>รถยนต์</option>
                <option>มอไซ</option>
                <option>รถบรรทุก</option>
              </select>
            </div>

            <div class="space-y-2">
              <label class="block text-sm font-medium text-gray-700">เวลาเข้า <span
                  class="text-red-500">*</span></label>
              <input v-model="form.entryTime"
                class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                type="datetime-local" required />
            </div>

            <div class="space-y-2">
              <label class="block text-sm font-medium text-gray-700">เวลาออก</label>
              <input v-model="form.exitTime"
                class="w-full px-4 py-2 border border-gray-300 rounded-lg focus:ring-2 focus:ring-blue-500 focus:border-blue-500 transition"
                type="datetime-local" />
            </div>

            <!-- Submit Button -->
            <div class="md:col-span-2 flex justify-end mt-4">
              <button type="submit"
                class="px-6 py-3 bg-blue-600 text-white font-medium rounded-lg hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2 transition flex items-center">
                <svg v-if="!editMode" xmlns="http://www.w3.org/2000/svg" class="h-5 w-5 mr-2" viewBox="0 0 20 20"
                  fill="currentColor">
                  <path fill-rule="evenodd"
                    d="M10 18a8 8 0 100-16 8 8 0 000 16zm1-11a1 1 0 10-2 0v2H7a1 1 0 100 2h2v2a1 1 0 102 0v-2h2a1 1 0 100-2h-2V7z"
                    clip-rule="evenodd" />
                </svg>
                <svg v-else xmlns="http://www.w3.org/2000/svg" class="h-5 w-5 mr-2" viewBox="0 0 20 20"
                  fill="currentColor">
                  <path
                    d="M13.586 3.586a2 2 0 112.828 2.828l-.793.793-2.828-2.828.793-.793zM11.379 5.793L3 14.172V17h2.828l8.38-8.379-2.83-2.828z" />
                </svg>
                {{ editMode ? 'อัปเดตข้อมูล' : 'บันทึกข้อมูล' }}
              </button>
            </div>
          </form>
        </div>

        <!-- Parking Preview -->
        <div v-if="form.plateNumber" class="mb-10">
          <h2 class="text-xl font-semibold mb-4 text-gray-800 border-b pb-2">ตัวอย่างบัตรจอดรถ</h2>
          <div class="border border-gray-200 rounded-xl p-6 bg-gradient-to-r from-blue-50 to-gray-50 shadow-inner">
            <div class="grid grid-cols-1 md:grid-cols-2 gap-4">
              <div class="space-y-3">
                <p class="flex items-center">
                  <span class="inline-block w-24 font-medium text-gray-700">ทะเบียน:</span>
                  <span class="font-semibold text-blue-600">{{ form.plateNumber || '-' }}</span>
                </p>
                <p class="flex items-center">
                  <span class="inline-block w-24 font-medium text-gray-700">ชื่อคนขับ:</span>
                  <span class="font-semibold">{{ form.driverName || '-' }}</span>
                </p>
                <p class="flex items-center">
                  <span class="inline-block w-24 font-medium text-gray-700">สีรถ:</span>
                  <span class="font-semibold">{{ form.carColor || '-' }}</span>
                </p>
              </div>
              <div class="space-y-3">
                <p class="flex items-center">
                  <span class="inline-block w-24 font-medium text-gray-700">ประเภทรถ:</span>
                  <span class="font-semibold">{{ form.carType || '-' }}</span>
                </p>
                <p class="flex items-center">
                  <span class="inline-block w-24 font-medium text-gray-700">เวลาเข้า:</span>
                  <span class="font-semibold">{{ formatDateTime(form.entryTime) || '-' }}</span>
                </p>
                <p class="flex items-center">
                  <span class="inline-block w-24 font-medium text-gray-700">เวลาออก:</span>
                  <span class="font-semibold">{{ formatDateTime(form.exitTime) || '-' }}</span>
                </p>
              </div>
            </div>
            <div class="mt-4 pt-4 border-t border-gray-200">
              <p class="flex items-center">
                <span class="inline-block w-24 font-medium text-gray-700">ราคา:</span>
                <span class="font-semibold text-green-600">
                  {{
                    form.carType.toLowerCase() === 'มอไซ' || form.carType.toLowerCase() === 'motorcycle'
                      ? 'นาทีละ 1.5 บาท'
                      : form.carType.toLowerCase() === 'รถยนต์' || form.carType.toLowerCase() === 'car'
                        ? 'นาทีละ 2.0 บาท'
                        : form.carType.toLowerCase() === 'รถบรรทุก' || form.carType.toLowerCase() === 'truck'
                          ? 'นาทีละ 3.0 บาท'
                          : 'ตามประเภทรถ'
                  }}
                </span>
              </p>
            </div>
          </div>
        </div>

        <!-- Parking Passes List -->
        <div v-if="parkingPasses.length > 0">
          <div class="flex justify-between items-center mb-4">
            <h2 class="text-xl font-semibold text-gray-800">รายการบัตรจอดรถ</h2>
            <span class="text-sm text-gray-500">ทั้งหมด {{ parkingPasses.length }} รายการ</span>
          </div>

          <div class="overflow-x-auto rounded-lg border border-gray-200 shadow">
            <table class="min-w-full divide-y divide-gray-200">
              <thead class="bg-gray-50">
                <tr>
                  <th scope="col"
                    class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">ทะเบียนรถ
                  </th>
                  <th scope="col"
                    class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">ชื่อคนขับ
                  </th>
                  <th scope="col"
                    class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">ประเภทรถ</th>
                  <th scope="col"
                  class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">สีรถ</th>
                  <th scope="col"
                    class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">เวลาเข้า</th>
                  <th scope="col"
                    class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">เวลาออก</th>
                  <th scope="col"
                    class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">ราคา</th>
                  <th scope="col"
                    class="px-6 py-3 text-right text-xs font-medium text-gray-500 uppercase tracking-wider">จัดการ</th>
                </tr>
              </thead>
              <tbody class="bg-white divide-y divide-gray-200">
                <tr v-for="(parkingPass, index) in parkingPasses" :key="index" class="hover:bg-gray-50 transition">
                  <td class="px-6 py-4 whitespace-nowrap">
                    <div class="font-medium text-blue-600">{{ parkingPass.plateNumber }}</div>
                  </td>
                  <td class="px-6 py-4 whitespace-nowrap">
                    <div class="text-gray-900">{{ parkingPass.driverName }}</div>
                  </td>
                  <td class="px-6 py-4 whitespace-nowrap">
                    <span class="px-2 inline-flex text-xs leading-5 font-semibold rounded-full" :class="{
                      'bg-green-100 text-green-800': parkingPass.carType === 'รถยนต์',
                      'bg-blue-100 text-blue-800': parkingPass.carType === 'มอไซ',
                      'bg-purple-100 text-purple-800': parkingPass.carType === 'รถบรรทุก'
                    }">
                      {{ parkingPass.carType }}
                    </span>
                  </td>
                  <td class="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
                    {{ parkingPass.carColor }}
                  </td>
                  <td class="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
                    {{ formatDateTime(parkingPass.entryTime) }}
                  </td>
                  <td class="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
                    {{ formatDateTime(parkingPass.exitTime) || '-' }}
                  </td>
                  <td class="px-6 py-4 whitespace-nowrap text-sm font-semibold text-green-600">
                    {{ parkingPass.price }}
                  </td>
                  <td class="px-6 py-4 whitespace-nowrap text-right text-sm font-medium">
                    <button @click="handleEdit(parkingPass.id)"
                      class="text-yellow-600 hover:text-yellow-900 mr-3 inline-flex items-center">
                      <svg xmlns="http://www.w3.org/2000/svg" class="h-4 w-4 mr-1" viewBox="0 0 20 20"
                        fill="currentColor">
                        <path
                          d="M13.586 3.586a2 2 0 112.828 2.828l-.793.793-2.828-2.828.793-.793zM11.379 5.793L3 14.172V17h2.828l8.38-8.379-2.83-2.828z" />
                      </svg>
                      แก้ไข
                    </button>
                    <button @click="handleDelete(parkingPass.id)"
                      class="text-red-600 hover:text-red-900 inline-flex items-center">
                      <svg xmlns="http://www.w3.org/2000/svg" class="h-4 w-4 mr-1" viewBox="0 0 20 20"
                        fill="currentColor">
                        <path fill-rule="evenodd"
                          d="M9 2a1 1 0 00-.894.553L7.382 4H4a1 1 0 000 2v10a2 2 0 002 2h8a2 2 0 002-2V6a1 1 0 100-2h-3.382l-.724-1.447A1 1 0 0011 2H9zM7 8a1 1 0 012 0v6a1 1 0 11-2 0V8zm5-1a1 1 0 00-1 1v6a1 1 0 102 0V8a1 1 0 00-1-1z"
                          clip-rule="evenodd" />
                      </svg>
                      ลบ
                    </button>
                  </td>
                  <td class="px-6 py-4 whitespace-nowrap text-right text-sm font-medium">
                    <!-- ปุ่มพิมพ์ -->
                    <button @click="printTicket(parkingPass)"
                      class="text-blue-600 hover:text-blue-900 mr-3 inline-flex items-center">
                      <svg xmlns="http://www.w3.org/2000/svg" class="h-4 w-4 mr-1" viewBox="0 0 20 20"
                        fill="currentColor">
                        <path fill-rule="evenodd"
                          d="M5 4v3H4a2 2 0 00-2 2v3a2 2 0 002 2h1v2a2 2 0 002 2h6a2 2 0 002-2v-2h1a2 2 0 002-2V9a2 2 0 00-2-2h-1V4a2 2 0 00-2-2H7a2 2 0 00-2 2zm8 0H7v3h6V4zm0 8H7v4h6v-4z"
                          clip-rule="evenodd" />
                      </svg>
                      พิมพ์
                    </button>
                    <!-- ปุ่มอื่นๆ... -->
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        </div>

        <!-- ส่วนสำหรับพิมพ์ (ซ่อนอยู่) -->
        <div v-if="printData" ref="printContent" class="hidden print:block p-6">
          <div class="border-2 border-gray-800 rounded-lg p-6 max-w-md mx-auto">
            <h2 class="text-xl font-bold text-center mb-4">บัตรจอดรถ</h2>
            <div class="grid grid-cols-2 gap-4 mb-6">
              <div>
                <p class="text-sm text-gray-600">ทะเบียนรถ</p>
                <p class="font-bold">{{ printData.plateNumber }}</p>
              </div>
              <div>
                <p class="text-sm text-gray-600">ชื่อคนขับ</p>
                <p class="font-bold">{{ printData.driverName }}</p>
              </div>
              <div>
                <p class="text-sm text-gray-600">สีรถ</p>
                <p class="font-bold">{{ printData.carColor }}</p>
              </div>
              <div>
                <p class="text-sm text-gray-600">ประเภทรถ</p>
                <p class="font-bold">{{ printData.carType }}</p>
              </div>
              <div>
                <p class="text-sm text-gray-600">เวลาเข้า</p>
                <p class="font-bold">{{ formatDateTime(printData.entryTime) }}</p>
              </div>
              <div>
                <p class="text-sm text-gray-600">เวลาออก</p>
                <p class="font-bold">{{ printData.exitTime ? formatDateTime(printData.exitTime) : '-' }}</p>
              </div>
            </div>
            <div class="border-t-2 border-gray-300 pt-4">
              <p class="text-lg font-bold text-right">ราคา: {{ printData.price }} บาท</p>
            </div>
            <div class="mt-8 text-center text-xs text-gray-500">
              <p>ขอบคุณที่ใช้บริการ</p>
              <p>{{ formatDateTime(new Date().toISOString()) }}</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">

import axios from 'axios'
import { ref, nextTick } from 'vue'

const printData = ref<any>(null)
const printContent = ref<HTMLElement | null>(null)

const formatDateTime = (dateTimeString: string) => {
  if (!dateTimeString) return '-'
  const date = new Date(dateTimeString)
  const day = date.getDate().toString().padStart(2, '0')
  const month = (date.getMonth() + 1).toString().padStart(2, '0')
  const year = date.getFullYear().toString().slice(-2)
  const hours = date.getHours().toString().padStart(2, '0')
  const minutes = date.getMinutes().toString().padStart(2, '0')
  return `${day}-${month}-${year} ${hours}:${minutes}`
}

const printTicket = (parkingPass: any) => {
  printData.value = parkingPass
  
  nextTick(() => {
    // เรียกหน้าต่างพิมพ์
    window.print()
  })
}
// ฟอร์มข้อมูล
const form = ref({
  plateNumber: '',
  driverName: '',
  carColor: '',
  carType: '',
  entryTime: '',
  exitTime: '',
})

const parkingPasses = ref([])
const editMode = ref(false)
const currentId = ref<number | null>(null)




// ฟังก์ชันดึงข้อมูลบัตรจอดรถทั้งหมด
const fetchParkingPasses = async () => {
  try {
    const response = await axios.get('http://localhost:5285/api/parkingpass')
    parkingPasses.value = response.data
  } catch (err) {
    console.error(err)
    alert('ไม่สามารถดึงข้อมูลบัตรจอดรถได้')
  }
}

// ฟังก์ชันบันทึกข้อมูล (หรืออัปเดตข้อมูล)
const handleSubmit = async () => {
  try {
    const dataToSend = editMode.value
      ? {
        Id: currentId.value, // <-- ใส่เฉพาะตอนแก้ไข
        PlateNumber: form.value.plateNumber,
        DriverName: form.value.driverName,
        CarColor: form.value.carColor,
        CarType: form.value.carType,
        EntryTime: form.value.entryTime,
        ExitTime: form.value.exitTime,
      }
      : {
        PlateNumber: form.value.plateNumber,
        DriverName: form.value.driverName,
        CarColor: form.value.carColor,
        CarType: form.value.carType,
        EntryTime: form.value.entryTime,
        ExitTime: form.value.exitTime,
      };



    console.log('👉 ส่งไปที่ API:', dataToSend)



    if (editMode.value) {
      // ถ้าอยู่ในโหมดแก้ไข, จะทำการ PUT (อัปเดต)
      await axios.put(`http://localhost:5285/api/parkingpass/${currentId.value}`, dataToSend, {
        headers: { 'Content-Type': 'application/json' }
      });

      alert('ข้อมูลถูกอัปเดตเรียบร้อย!');
    } else {
      await axios.post('http://localhost:5285/api/parkingpass', dataToSend, {
        headers: {
          'Content-Type': 'application/json'
        }
      });
    }

    // รีเฟรชรายการ
    fetchParkingPasses();

    resetForm();
  } catch (err) {
    console.error('Error occurred:', err);
    alert('เกิดข้อผิดพลาดในการบันทึก');
  }
}

// ฟังก์ชันแก้ไขข้อมูล
const handleEdit = (id: number) => {
  const parkingPass = parkingPasses.value.find(p => p.id === id);
  if (parkingPass) {
    form.value.plateNumber = parkingPass.plateNumber;
    form.value.driverName = parkingPass.driverName;
    form.value.carColor = parkingPass.carColor;
    form.value.carType = parkingPass.carType;
    form.value.entryTime = parkingPass.entryTime
    form.value.exitTime = parkingPass.exitTime



    // ตั้งค่าโหมดแก้ไขและเก็บ ID ของรายการที่แก้ไข
    editMode.value = true;
    currentId.value = id;
  }
}

// ฟังก์ชันลบข้อมูล
const handleDelete = async (id: number) => {
  if (confirm('คุณแน่ใจว่าต้องการลบรายการนี้?')) {
    try {
      await axios.delete(`http://localhost:5285/api/parkingpass/${id}`);
      alert('ลบข้อมูลเรียบร้อย!');
      fetchParkingPasses(); // รีเฟรชรายการ
    } catch (err) {
      console.error(err);
      alert('เกิดข้อผิดพลาดในการลบ');
    }
  }
}

// ฟังก์ชันรีเซ็ตฟอร์ม
const resetForm = () => {
  form.value.plateNumber = '';
  form.value.driverName = '';
  form.value.carColor = '';
  form.value.carType = '';

  form.value.entryTime = ''
  form.value.exitTime = ''

  editMode.value = false;
  currentId.value = null;
}

// เรียกใช้งานเมื่อเริ่มต้นเพื่อดึงข้อมูล
fetchParkingPasses();

</script>

<style scoped>
/* ซ่อนทุกอย่างเมื่อพิมพ์ ยกเว้นส่วนที่ต้องการ */
@media print {
  body * {
    visibility: hidden;
  }
  .print\:block, .print\:block * {
    visibility: visible;
  }
  .print\:block {
    position: fixed;
    left: 0;
    top: 0;
    width: 100vw;
    height: 100vh;
    background: white;
    z-index: 9999;
  }
}
</style>