<!-- components/ParkingTicketPrint.vue -->
<template>
    <div class="p-6 print:p-0">
      <div class="border-2 border-gray-800 rounded-lg p-6 max-w-md mx-auto">
        <h2 class="text-xl font-bold text-center mb-4">บัตรจอดรถ</h2>
        <div class="grid grid-cols-2 gap-4 mb-6">
          <div>
            <p class="text-sm text-gray-600">ทะเบียนรถ</p>
            <p class="font-bold">{{ ticket.plateNumber }}</p>
          </div>
          <div>
            <p class="text-sm text-gray-600">ชื่อคนขับ</p>
            <p class="font-bold">{{ ticket.driverName }}</p>
          </div>
          <div>
            <p class="text-sm text-gray-600">สีรถ</p>
            <p class="font-bold">{{ ticket.carColor }}</p>
          </div>
          <div>
            <p class="text-sm text-gray-600">ประเภทรถ</p>
            <p class="font-bold">{{ ticket.carType }}</p>
          </div>
          <div>
            <p class="text-sm text-gray-600">เวลาเข้า</p>
            <p class="font-bold">{{ formatDateTime(ticket.entryTime) }}</p>
          </div>
          <div>
            <p class="text-sm text-gray-600">เวลาออก</p>
            <p class="font-bold">{{ ticket.exitTime ? formatDateTime(ticket.exitTime) : '-' }}</p>
          </div>
        </div>
        <div class="border-t-2 border-gray-300 pt-4">
          <p class="text-lg font-bold text-right">ราคา: {{ ticket.price }} บาท</p>
        </div>
        <div class="mt-8 text-center text-xs text-gray-500">
          <p>ขอบคุณที่ใช้บริการ</p>
          <p>{{ currentDate }}</p>
        </div>
      </div>
      <div class="mt-6 text-center print:hidden">
        <button 
          @click="printTicket"
          class="bg-blue-600 text-white px-6 py-2 rounded-lg hover:bg-blue-700"
        >
          พิมพ์บัตร
        </button>
      </div>
    </div>
  </template>
  
  <script setup lang="ts">
  import { computed } from 'vue'
  
  const props = defineProps({
    ticket: {
      type: Object,
      required: true
    }
  })
  
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
  
  const currentDate = computed(() => {
    return formatDateTime(new Date().toISOString())
  })
  
  const printTicket = () => {
    window.print()
  }
  </script>
  
  <style>
  @media print {
    body {
      -webkit-print-color-adjust: exact;
      margin: 0;
      padding: 0;
    }
    @page {
      size: auto;
      margin: 10mm;
    }
  }
  </style>